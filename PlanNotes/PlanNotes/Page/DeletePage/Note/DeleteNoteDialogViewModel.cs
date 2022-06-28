using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class DeleteNoteDialogViewModel : ViewModelBase
    {
        public DeleteNoteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Notes = WeakReferenceMessenger.Default.Send<NotesRequestMessage>().Response;
            Note = WeakReferenceMessenger.Default.Send<NoteRequestMessage>().Response;
        }

        public ObservableCollection<Note> Notes { get; set; }
        public Note Note { get; set; }

        // RelayCommand
        private RelayCommand _deleteNoteCommand;
        public RelayCommand DeleteNoteCommand => _deleteNoteCommand ?? (_deleteNoteCommand = new RelayCommand(() =>
        {
            Notes.Remove(Note);
            dataService.RemoveNote(Note);
            dialogService.HideCurrentDialog();
        }));

        private RelayCommand _hideDialogCommand;
        public RelayCommand HideDialogCommand => _hideDialogCommand ?? (_hideDialogCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
