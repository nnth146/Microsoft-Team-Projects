using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class FolderPageViewModel : ViewModelBase
    {
        public FolderPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Folder = WeakReferenceMessenger.Default.Send<FolderRequestMessage>().Response;
            Notes = Folder.FolderNotes;
            Notes.CollectionChanged += Notes_CollectionChanged;
            getIsCompleted();
        }

        private void Notes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                dataService.SaveChanges();
            }
            OnPropertyChanged(nameof(Notes));
            getIsCompleted();
        }

        private void getIsCompleted()
        {
            Completed = UnCompleted = 0;
            for (int i = 0; i < Notes.Count; i++)
            {

                if (Notes[i].IsCompleted)
                    Completed++;
                else UnCompleted++;
            }
            OnPropertyChanged(nameof(Completed));
            OnPropertyChanged(nameof(UnCompleted));
        }

        public Folder Folder { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        public int UnCompleted { get; set; }
        public int Completed { get; set; }

        // Changed Note
        private RelayCommand<Note> _completedNoteCommand;
        public RelayCommand<Note> CompletedNoteCommand => _completedNoteCommand ?? (_completedNoteCommand = new RelayCommand<Note>((selectedNote) =>
        {
            selectedNote.IsCompleted = !selectedNote.IsCompleted;
            for (int i = 0; i < Notes.Count; i++)
            {
                if (Notes[i].NoteId == selectedNote.NoteId)
                {
                    Notes[i] = selectedNote;
                    break;
                }
            }
        }));

        // Add new Note
        private RelayCommand _addNoteCommand;
        public RelayCommand AddNoteCommand => _addNoteCommand ?? (_addNoteCommand = new RelayCommand(async () =>
        {
            WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
            {
                m.Reply(Folder);
            });
            WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
            {
                m.Reply(Notes);
            });
            await dialogService.showAsync(typeof(AddNoteFolderDialogViewModel));
            WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
            WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
        }));

        // Delete Note
        private RelayCommand<Note> _deleteNoteCommand;
        public RelayCommand<Note> DeleteNoteCommand => _deleteNoteCommand ?? (_deleteNoteCommand = new RelayCommand<Note>(async (selectedNote) =>
        {
            if (selectedNote != null)
            {
                WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
                {
                    m.Reply(Notes);
                });
                WeakReferenceMessenger.Default.Register<NoteRequestMessage>(this, (r, m) =>
                {
                    m.Reply(selectedNote);
                });
                await dialogService.showAsync(typeof(DeleteNoteDialogViewModel));
                WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<NoteRequestMessage>(this);
            }
        }));

        // Show and Edit Note
        private RelayCommand<Note> _showAndEditNoteCommand;
        public RelayCommand<Note> ShowAndEditNoteCommand => _showAndEditNoteCommand ?? (_showAndEditNoteCommand = new RelayCommand<Note>(async (selectedNote) =>
        {
            if (selectedNote != null)
            {
                WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
                {
                    m.Reply(Notes);
                });
                WeakReferenceMessenger.Default.Register<NoteRequestMessage>(this, (r, m) =>
                {
                    m.Reply(selectedNote);
                });
                WeakReferenceMessenger.Default.Register<DateTimeRequestMessage>(this, (r, m) =>
                {
                    m.Reply(selectedNote.NoteDueDate);
                });
                await dialogService.showAsync(typeof(ViewAndEditNoteDialogViewModel));
                WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<NoteRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<DateTimeRequestMessage>(this);
            }
        }));
    }
}
