using System.Collections.ObjectModel;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public interface IDataService
    {
        int SaveChanges();

        ObservableCollection<Plan> GetPlans();

        void AddNewPlan(Plan Plan);

        void RemovePlan(Plan Plan);

        ObservableCollection<Folder> GetFolders();
        Folder GetFolder(int FolderId);

        void AddNewFolder(Folder Folder);

        void RemoveFolder(Folder Folder);

        ObservableCollection<Note> GetNotes();

        void AddNewNote(Note Note);

        void RemoveNote(Note Note);

        ObservableCollection<CheckList> GetCheckLists();

        ObservableCollection<CheckList> GetCheckListsByWhere(int checkListId);

        void AddNewCheckList(CheckList CheckList);

        void RemoveCheckList(CheckList CheckList);

        ObservableCollection<Step> GetSteps();

        ObservableCollection<Step> GetStepsByWhere(int id);

        void AddNewStep(Step step);

        void RemoveStep(Step step);
    }
}
