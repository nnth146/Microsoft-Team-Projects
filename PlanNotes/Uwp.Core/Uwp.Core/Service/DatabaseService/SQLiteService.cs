using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public class SQLiteService : IDataService
    {
        private readonly static DataContext _db = new DataContext();
        public DataContext Db => _db;

        // Save
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        // Get all Plan
        public ObservableCollection<Plan> GetPlans()
        {
            return new ObservableCollection<Plan>(
                list: Db.Plans
                .Include(x => x.PlanFolders)
                .ToList()); ;
        }

        // Add new Plan
        public void AddNewPlan(Plan Plan)
        {
            Db.Plans.Add(Plan);
            SaveChanges();
        }

        // Delete Plan
        public void RemovePlan(Plan Plan)
        {
            Db.Plans.Remove(Plan);
            SaveChanges();
        }

        // Get all Folder
        public ObservableCollection<Folder> GetFolders()
        {
            return new ObservableCollection<Folder>(
                list: Db.Folders
                .Include(x => x.FolderNotes)
                .ToList());
        }

        // Get Folder
        public Folder GetFolder(int FolderId)
        {
            return
                Db.Folders
                .First(x => x.FolderId == FolderId);
        }

        // Add new Folder
        public void AddNewFolder(Folder Folder)
        {
            Db.Folders.Add(Folder);
            SaveChanges();
        }

        // Delete Folder
        public void RemoveFolder(Folder Folder)
        {
            Db.Folders.Remove(Folder);
            SaveChanges();
        }

        // Get all Note
        public ObservableCollection<Note> GetNotes()
        {
            return new ObservableCollection<Note>(
                list: Db.Notes
                .Include(x => x.NoteCheckLists)
                .ToList());
        }

        // Add new Note
        public void AddNewNote(Note Note)
        {
            Db.Notes.Add(Note);
            SaveChanges();
        }

        // Delete Note
        public void RemoveNote(Note Note)
        {
            Db.Notes.Remove(Note);
            SaveChanges();
        }

        // Get all CheckList
        public ObservableCollection<CheckList> GetCheckLists()
        {
            return new ObservableCollection<CheckList>(
                list: Db.CheckLists
                .Include(x => x.CheckListSteps)
                .ToList()); ;
        }

        // Get CheckList By Where
        public ObservableCollection<CheckList> GetCheckListsByWhere(int checkListId)
        {
            return new ObservableCollection<CheckList>(
                list: Db.CheckLists
                .Where(x => x.CheckListId == checkListId)
                .ToList());
        }

        // Add new CheckList
        public void AddNewCheckList(CheckList CheckList)
        {
            Db.CheckLists.Add(CheckList);
            SaveChanges();
        }

        // Delete CheckList
        public void RemoveCheckList(CheckList CheckList)
        {
            Db.CheckLists.Remove(CheckList);
            SaveChanges();
        }

        // Get all Step
        public ObservableCollection<Step> GetSteps()
        {
            return new ObservableCollection<Step>(
                list: Db.Steps
                .ToList());
        }

        // Get Step By Where
        public ObservableCollection<Step> GetStepsByWhere(int id)
        {
            return new ObservableCollection<Step>(
                list: Db.Steps
                .Where(x => x.CheckListId == id)
                .ToList());
        }

        // Add new Step
        public void AddNewStep(Step step)
        {
            Db.Steps.Add(step);
            SaveChanges();
        }

        // Delete CheckList
        public void RemoveStep(Step step)
        {
            Db.Steps.Remove(step);
        }
    }
}
