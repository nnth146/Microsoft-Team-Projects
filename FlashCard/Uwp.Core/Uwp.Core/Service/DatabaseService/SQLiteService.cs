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


        // Save Change
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        // Get all Folder
        public ObservableCollection<FolderModel> GetFolders()
        {
            return new ObservableCollection<FolderModel>(
                list: Db.Folders
                .Include(x => x.StudyModels)
                .ToList());
        }

        // Add new Folder
        public void AddNewFolder(FolderModel FolderModel)
        {
            Db.Folders.Add(FolderModel);
            SaveChanges();
        }

        // Delete Folder
        public void RemoveFolder(FolderModel FolderModel)
        {
            Db.Folders.Remove(FolderModel);
            SaveChanges();
        }

        // Get all Topic
        public ObservableCollection<TopicModel> GetTopics()
        {
            return new ObservableCollection<TopicModel>(
                list: Db.Topics
                .ToList()); ;
        }

        // Add new Topic
        public void AddNewTopic(TopicModel TopicModel)
        {
            Db.Topics.Add(TopicModel);
            SaveChanges();
        }

    }
}
