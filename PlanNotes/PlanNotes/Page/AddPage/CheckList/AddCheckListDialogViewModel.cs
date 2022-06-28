using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class AddCheckListDialogViewModel : ViewModelBase
    {
        public AddCheckListDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            CheckLists = WeakReferenceMessenger.Default.Send<CheckListsRequestMessage>().Response;
            SelectedNote = WeakReferenceMessenger.Default.Send<NoteRequestMessage>().Response;
            Notes = WeakReferenceMessenger.Default.Send<NotesRequestMessage>().Response;
            dateTime = WeakReferenceMessenger.Default.Send<DateTimeRequestMessage>().Response;
            NameCheckList = "";
        }

        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        public DateTime dateTime { get; set; }
        public Note SelectedNote { get; set; }
        public string NameCheckList { get; set; }

        private RelayCommand _addCheckListComamnd;
        public RelayCommand AddCheckListCommand => _addCheckListComamnd ?? (_addCheckListComamnd = new RelayCommand(async () =>
        {
            CheckList CheckList = new CheckList();
            CheckList.CheckListName = string.IsNullOrEmpty(NameCheckList) ? "CheckList..." : NameCheckList;
            CheckList.CheckListSteps = new ObservableCollection<Step>();
            CheckList.CheckListCreate_On = DateTime.Now.ToLocalTime();
            CheckList.NoteId = SelectedNote.NoteId;
            dataService.AddNewCheckList(CheckList);
            dialogService.HideCurrentDialog();
            WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
            {
                m.Reply(Notes);
            });
            WeakReferenceMessenger.Default.Register<NoteRequestMessage>(this, (r, m) =>
            {
                m.Reply(SelectedNote);
            });
            WeakReferenceMessenger.Default.Register<DateTimeRequestMessage>(this, (r, m) =>
            {
                m.Reply(dateTime);
            });
            await dialogService.showAsync(typeof(ViewAndEditNoteDialogViewModel));
            WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
            WeakReferenceMessenger.Default.Unregister<NoteRequestMessage>(this);
            WeakReferenceMessenger.Default.Unregister<DateTimeRequestMessage>(this);
        }));

        private RelayCommand _hideDialogCommand;
        public RelayCommand HideDialogCommand => _hideDialogCommand ?? (_hideDialogCommand = new RelayCommand(() =>
        {
            dialogService.HideCurrentDialog();
        }));
    }
}
