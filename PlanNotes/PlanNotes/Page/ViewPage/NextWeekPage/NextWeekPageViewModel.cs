using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class NextWeekPageViewModel : ViewModelBase
    {
        public NextWeekPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            dateTime = DateTime.Now.ToLocalTime().AddDays(+7);
            Notes = dataService.GetNotes();
            Steps = dataService.GetSteps();
            NotesToday = new ObservableCollection<Note>();
            foreach (Note note in Notes)
            {
                if (note.NoteDueDate.Date == DateTime.Now.ToLocalTime().Date.AddDays(+7))
                    NotesToday.Add(note);
            }

            for (int i = 0; i < NotesToday.Count; i++)
            {
                int temp1 = 0;
                int temp2 = 0;
                for (int j = 0; j < NotesToday[i].NoteCheckLists.Count; j++)
                {
                    for (int k = 0; k < NotesToday[i].NoteCheckLists[j].CheckListSteps.Count; k++)
                    {
                        temp1++;
                        if (NotesToday[i].NoteCheckLists[j].CheckListSteps[k].StepStatus)
                            temp2++;
                    }
                }
                NotesToday[i].AmountStep = temp1;
                NotesToday[i].StepCompleted = temp2;
                dataService.SaveChanges();
            }

            NotesToday.CollectionChanged += NotesToday_CollectionChanged;

            Filter = new ObservableCollection<string>()
            {
                "Sort by Folder",
                "Sort by Plan"
            };
            SelectedFilter = Filter[0];
            getVs();
        }

        private void getVs()
        {
            if (SelectedFilter == "Sort by Folder")
            {
                Vs = new ObservableGroupedCollection<object, Note>(NotesToday.GroupBy(x => x.Folder, x => x));
                isPlan = false;
            }
            else
            {
                isPlan = true;
                Vs = new ObservableGroupedCollection<object, Note>(NotesToday.GroupBy(x => x.Folder.Plan, x => x));
            }
            OnPropertyChanged(nameof(isPlan));
            OnPropertyChanged(nameof(Vs));
        }

        private void NotesToday_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.AddNewNote(e.NewItems[0] as Note);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                dataService.SaveChanges();
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
            }
            OnPropertyChanged(nameof(NotesToday));
            getVs();
        }

        public ObservableGroupedCollection<object, Note> Vs { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        public ObservableCollection<Note> NotesToday { get; set; }
        public int NoteTodayCount { get => NotesToday.Count; }
        public ObservableCollection<Step> Steps { get; set; }
        public ObservableCollection<string> Filter { get; set; }
        public string SelectedFilter { get; set; }
        public DateTime dateTime { get; set; }
        public bool isPlan { get; set; }

        #region Command
        // Add new Note
        private RelayCommand _seletedFilterCommand;
        public RelayCommand SeletedFilterCommand => _seletedFilterCommand ?? (_seletedFilterCommand = new RelayCommand(() =>
        {
            OnPropertyChanged(nameof(SelectedFilter));

            getVs();
        }));

        // Add new Note
        private RelayCommand _addNoteCommand;
        public RelayCommand AddNoteCommand => _addNoteCommand ?? (_addNoteCommand = new RelayCommand(async () =>
        {
            WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
            {
                m.Reply(NotesToday);
            });
            WeakReferenceMessenger.Default.Register<DateTimeRequestMessage>(this, (r, m) =>
            {
                m.Reply(dateTime);
            });
            await dialogService.showAsync(typeof(AddNoteDialogViewModel));
            WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
            WeakReferenceMessenger.Default.Unregister<DateTimeRequestMessage>(this);
        }));

        // Show and Edit Note
        private RelayCommand<Note> _showAndEditNoteCommand;
        public RelayCommand<Note> ShowAndEditNoteCommand => _showAndEditNoteCommand ?? (_showAndEditNoteCommand = new RelayCommand<Note>(async (selectedNote) =>
        {
            if (selectedNote != null)
            {
                WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
                {
                    m.Reply(NotesToday);
                });
                WeakReferenceMessenger.Default.Register<NoteRequestMessage>(this, (r, m) =>
                {
                    m.Reply(selectedNote);
                });
                WeakReferenceMessenger.Default.Register<DateTimeRequestMessage>(this, (r, m) =>
                {
                    m.Reply(dateTime);
                });
                await dialogService.showAsync(typeof(ViewAndEditNoteDialogViewModel));
                WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<NoteRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<DateTimeRequestMessage>(this);
            }
        }));

        // Changed Note
        private RelayCommand<Note> _completedNoteCommand;
        public RelayCommand<Note> CompletedNoteCommand => _completedNoteCommand ?? (_completedNoteCommand = new RelayCommand<Note>((selectedNote) =>
        {
            selectedNote.IsCompleted = !selectedNote.IsCompleted;
            for (int i = 0; i < NotesToday.Count; i++)
            {
                if (NotesToday[i].NoteId == selectedNote.NoteId)
                {
                    NotesToday[i] = selectedNote;
                    break;
                }
            }
        }));

        // Delete Note
        private RelayCommand<Note> _deleteNoteCommand;
        public RelayCommand<Note> DeleteNoteCommand => _deleteNoteCommand ?? (_deleteNoteCommand = new RelayCommand<Note>(async (selectedNote) =>
        {
            if (selectedNote != null)
            {
                WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
                {
                    m.Reply(NotesToday);
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
        #endregion
    }
}
