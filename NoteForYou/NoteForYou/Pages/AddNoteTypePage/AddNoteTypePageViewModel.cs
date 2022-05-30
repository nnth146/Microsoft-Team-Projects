using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using NoteForYou.Messenger;
using NoteForYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Service;

namespace NoteForYou.ViewModel
{
    public class AddNoteTypePageViewModel : ViewModelBase
    {
        public AddNoteTypePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
        }

        public override void InitializeComponent()
        {
            
        }

        public string Title { get; set; }
        public string Note { get; set; }

        private RelayCommand _saveNoteCommand;
        public RelayCommand SaveNoteCommand => _saveNoteCommand ?? (_saveNoteCommand = new RelayCommand(async () =>
        {
            if(string.IsNullOrEmpty(Title) && string.IsNullOrWhiteSpace(Title))
            {
                return;
            }
            var addedNote = new BasicNote
            {
                Title = Title,
                Note = Note,
            };
            using (var db = new DataContext())
            {
                db.BasicNotes.Add(addedNote);
                await db.SaveChangesAsync();
            }

            messengerService.Send<NotesPageUpdateUIBehavior>();
            messengerService.Send<AddNotePageGoBackBeHavior>();
        }));

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
        {
            messengerService.Send<AddNotePageGoBackBeHavior>();
        }));
    }
}
