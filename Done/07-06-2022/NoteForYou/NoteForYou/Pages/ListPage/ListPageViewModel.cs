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
    public class ListPageViewModel : ViewModelBase
    {
        public ListPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        public override void InitializeComponent()
        {
            SelectedNote = messengerService.Send<SelectedNoteRequestMessage>().Response as ListNote;
        }

        private string _titleSubNote;
        public string TitleSubNote
        {
            get { return _titleSubNote; }
            set { SetProperty(ref _titleSubNote, value); }
        }
        public ListNote SelectedNote { get; set; }

        private RelayCommand _saveEditCommand;
        public RelayCommand SaveEditCommand => _saveEditCommand ?? (_saveEditCommand = new RelayCommand(() =>
        {
            SelectedNote.UpdatedOn = DateTime.Now;
            messengerService.Send<SaveChangeDb>();
        }));

        private RelayCommand _addSubNoteCommand;
        public RelayCommand AddSubNoteCommand => _addSubNoteCommand ?? (_addSubNoteCommand = new RelayCommand(() =>
        {
            var subNote = new SubNote
            {
                Title = string.IsNullOrEmpty(TitleSubNote) ? "New Note" : TitleSubNote,
                IsChecked = false
            };
            SelectedNote.SubNotes.Add(subNote);
            SelectedNote.UpdatedOn = DateTime.Now;
            TitleSubNote = "";
            messengerService.Send<SaveChangeDb>();
        }));
        private RelayCommand<SubNote> _deleteSubNoteCommand;
        public RelayCommand<SubNote> DeleteSubNoteCommand => _deleteSubNoteCommand ?? (_deleteSubNoteCommand = new RelayCommand<SubNote>((deletedSubNote) =>
        {
            SelectedNote.SubNotes.Remove(deletedSubNote);
            SelectedNote.UpdatedOn = DateTime.Now;
            messengerService.Send<SaveChangeDb>();
        }));
    }
}
