using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using NoteForYou.Messenger;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.StoreService;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public class AddListTypePageViewModel : ViewModelBase
    {
        public AddListTypePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }

        public override void InitializeComponent()
        {
            
        }
        public string Title { get; set; }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        public ObservableCollection<SubNote> SubNotes { get; set; } = new ObservableCollection<SubNote>();

        private RelayCommand _saveNoteCommand;
        public RelayCommand SaveNoteCommand => _saveNoteCommand ?? (_saveNoteCommand = new RelayCommand(async () =>
        {
            if (string.IsNullOrEmpty(Title) && string.IsNullOrWhiteSpace(Title))
            {
                return;
            }

            bool isPremium = StoreHelper.Default.IsPremium;
            uint balance = StoreHelper.Default.Balance;

            if (isPremium)
            {
                SaveNote();
                return;
            }
            if (balance > 0)
            {
                StoreHelper.Default.FulfillConsumable();
                SaveNote();
                return;
            }

            await dialogService.showAsync(typeof(WaitingDialogViewModel));
            SaveNote();
        }));

        private async void SaveNote()
        {
            var addedNote = new ListNote
            {
                Title = Title,
                SubNotes = SubNotes,
            };
            using (var db = new DataContext())
            {
                db.ListNotes.Add(addedNote);
                await db.SaveChangesAsync();
            }

            messengerService.Send<NotesPageUpdateUIBehavior>();
            messengerService.Send<AddNotePageGoBackBeHavior>();
        }

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
        {
            messengerService.Send<AddNotePageGoBackBeHavior>();
        }));

        //Thêm sub note
        private RelayCommand _addSubNoteCommand;
        public RelayCommand AddSubNoteCommand => _addSubNoteCommand ?? (_addSubNoteCommand = new RelayCommand(() =>
        {
            var subNote = new SubNote
            {
                Title = String.IsNullOrEmpty(Text) ? "New Sub Note" : Text,
                IsChecked = false,
            };
            SubNotes.Add(subNote);
            Text = "";
        }));

        private RelayCommand<SubNote> _removeSubNoteCommand;
        public RelayCommand<SubNote> RemoveSubNoteCommand => _removeSubNoteCommand ?? (_removeSubNoteCommand = new RelayCommand<SubNote>((deletedItem) =>
        {
            SubNotes.Remove(deletedItem);
        }));
    }
}
