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
    public class ViewAndEditNoteDialogViewModel : ViewModelBase
    {
        public ViewAndEditNoteDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Notes = WeakReferenceMessenger.Default.Send<NotesRequestMessage>().Response;
            SelectedNote = WeakReferenceMessenger.Default.Send<NoteRequestMessage>().Response;
            dateTime = WeakReferenceMessenger.Default.Send<DateTimeRequestMessage>().Response;
            SelectedNote.Folder = dataService.GetFolder(SelectedNote.FolderId);
            DueDate = new DateTimeOffset(SelectedNote.NoteDueDate);
            CheckLists = new ObservableCollection<CheckList>();
            if (SelectedNote.NoteCheckLists.Count > 0)
            {
                CheckLists = SelectedNote.NoteCheckLists;
            }
            CheckLists.CollectionChanged += CheckLists_CollectionChanged;

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

        private void CheckLists_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                dataService.SaveChanges();
            }
            OnPropertyChanged(nameof(CheckLists));
        }

        public ObservableCollection<Note> ViewNotes;
        public ObservableCollection<Note> Notes { get; set; }
        public Note SelectedNote { get; set; }
        public ObservableCollection<CheckList> CheckLists { get; set; }
        public ObservableCollection<Step> Steps { get; set; }
        public bool HasCheckList { get; set; }
        public bool IsEnable { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTime dateTime { get; set; }

        // RelayCommand
        private RelayCommand _addCheckListCommand;
        public RelayCommand AddCheckListCommand => _addCheckListCommand ?? (_addCheckListCommand = new RelayCommand(async () =>
        {
            WeakReferenceMessenger.Default.Register<NotesRequestMessage>(this, (r, m) =>
            {
                m.Reply(Notes);
            });
            WeakReferenceMessenger.Default.Register<DateTimeRequestMessage>(this, (r, m) =>
            {
                m.Reply(dateTime);
            });
            dialogService.HideCurrentDialog();
            WeakReferenceMessenger.Default.Unregister<NotesRequestMessage>(this);
            WeakReferenceMessenger.Default.Unregister<DateTimeRequestMessage>(this);

            WeakReferenceMessenger.Default.Register<CheckListsRequestMessage>(this, (r, m) =>
            {
                m.Reply(CheckLists);
            });
            await dialogService.showAsync(typeof(AddCheckListDialogViewModel));
            WeakReferenceMessenger.Default.Unregister<CheckListsRequestMessage>(this);
        }));

        private RelayCommand<CheckList> _deleteCheckListCommand;
        public RelayCommand<CheckList> DeleteCheckListCommand => _deleteCheckListCommand ?? (_deleteCheckListCommand = new RelayCommand<CheckList>((selectedCheckList) =>
        {
            dataService.RemoveCheckList(selectedCheckList);
        }));

        private RelayCommand<CheckList> _addStepCommand;
        public RelayCommand<CheckList> AddStepCommand => _addStepCommand ?? (_addStepCommand = new RelayCommand<CheckList>((selectedCheckList) =>
        {
            Step step = new Step();
            step.StepName = "Check List";
            step.StepStatus = false;
            step.CheckListId = selectedCheckList.CheckListId;
            dataService.AddNewStep(step);
            setPercent(selectedCheckList);
        }));

        private RelayCommand<Step> _deleteStepCommand;
        public RelayCommand<Step> DeleteStepCommand => _deleteStepCommand ?? (_deleteStepCommand = new RelayCommand<Step>((selectedStep) =>
        {
            CheckList checkList = dataService.GetCheckListsByWhere(selectedStep.CheckListId)[0];
            dataService.RemoveStep(selectedStep);
            setPercent(checkList);
        }));

        private RelayCommand<Step> _checkStepStatusCommand;
        public RelayCommand<Step> CheckStepStatusCommand => _checkStepStatusCommand ?? (_checkStepStatusCommand = new RelayCommand<Step>((selectedStep) =>
        {
            selectedStep.StepStatus = !selectedStep.StepStatus;
            CheckList checkList = dataService.GetCheckListsByWhere(selectedStep.CheckListId)[0];
            for (int i = 0; i < checkList.CheckListSteps.Count; i++)
            {
                if (checkList.CheckListSteps[i].StepId == selectedStep.StepId)
                {
                    checkList.CheckListSteps[i] = selectedStep;
                }
            }
            setPercent(checkList);
        }));

        private RelayCommand<CheckList> _changedAllStepStatusCommand;
        public RelayCommand<CheckList> ChangedAllStepStatusCommand => _changedAllStepStatusCommand ?? (_changedAllStepStatusCommand = new RelayCommand<CheckList>((selectedCheckList) =>
        {
            for (int i = 0; i < selectedCheckList.CheckListSteps.Count; i++)
            {
                selectedCheckList.CheckListSteps[i].StepStatus = true;
            }
            setPercent(selectedCheckList);
        }));

        private RelayCommand _saveValueCommand;
        public RelayCommand SaveValueCommand => _saveValueCommand ?? (_saveValueCommand = new RelayCommand(() =>
        {
            DateTime NoteDueDate = new DateTime(DueDate.Year, DueDate.Month, DueDate.Day);
            SelectedNote.NoteDueDate = NoteDueDate;
            dataService.SaveChanges();
            if (SelectedNote.NoteDueDate.Day != dateTime.Day || SelectedNote.NoteDueDate.Month != dateTime.Month || SelectedNote.NoteDueDate.Year != dateTime.Year)
            {
                Notes.Remove(SelectedNote);
                dataService.SaveChanges();
            }
            else
            {
                for (int i = 0; i < Notes.Count; i++)
                {
                    if (Notes[i].NoteId == SelectedNote.NoteId)
                    {
                        Notes[i] = SelectedNote;
                        break;
                    }
                }
                for (int i = 0; i < Notes.Count; i++)
                {
                    int temp1 = 0;
                    int temp2 = 0;
                    for (int j = 0; j < Notes[i].NoteCheckLists.Count; j++)
                    {
                        for (int k = 0; k < Notes[i].NoteCheckLists[j].CheckListSteps.Count; k++)
                        {
                            temp1++;
                            if (Notes[i].NoteCheckLists[j].CheckListSteps[k].StepStatus)
                                temp2++;
                        }
                    }
                    Notes[i].AmountStep = temp1;
                    Notes[i].StepCompleted = temp2;
                }
            }
            dialogService.HideCurrentDialog();
        }));

        public void setPercent(CheckList checkList)
        {
            double count = 0;
            for (int i = 0; i < checkList.CheckListSteps.Count; i++)
            {
                if (checkList.CheckListSteps[i].StepStatus)
                {
                    count = count + 1;
                }
            }
            checkList.Percent = count / checkList.CheckListSteps.Count * 100;
            for (int i = 0; i < CheckLists.Count; i++)
            {
                if (CheckLists[i].CheckListId == checkList.CheckListId)
                {
                    CheckLists[i] = checkList;
                    break;
                }
            }
        }
    }
}
