using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;

namespace PlanNotes.ViewModel
{
    public class ShowNoteDialogViewModel : ViewModelBase
    {
        public ShowNoteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Notes = WeakReferenceMessenger.Default.Send<NotesRequestMessage>().Response;
            SelectedNote = WeakReferenceMessenger.Default.Send<NoteRequestMessage>().Response;
            SelectedNote.Folder = dataService.GetFolder(SelectedNote.FolderId);
            CheckLists = new ObservableCollection<CheckList>();
            if (SelectedNote.NoteCheckLists.Count > 0)
            {
                CheckLists = SelectedNote.NoteCheckLists;
            }

            if (CheckLists.Count > 0) HasCheckList = true;
            else HasCheckList = false;
            OnPropertyChanged(nameof(HasCheckList));
            GetValue();

            IsEnable = false;
        }

        public void GetValue()
        {
            foreach (CheckList checkList in CheckLists)
            {
                checkList.CheckListSteps = dataService.GetStepsByWhere(checkList.CheckListId);
            }
            dataService.SaveChanges();
        }

        public ObservableCollection<Note> ViewNotes;
        public ObservableCollection<Note> Notes { get; set; }
        public Note SelectedNote { get; set; }
        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<Step> Steps { get; set; }
        public bool HasCheckList { get; set; }
        public bool IsEnable { get; set; }
    }
}
