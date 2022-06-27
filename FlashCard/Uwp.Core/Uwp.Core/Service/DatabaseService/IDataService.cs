using System.Collections.ObjectModel;
using Uwp.SQLite.Model;

namespace Uwp.Core.Service
{
    public interface IDataService
    {
        int SaveChanges();
        ObservableCollection<FolderModel> GetFolders();
        void AddNewFolder(FolderModel FolderModel);
        void RemoveFolder(FolderModel FolderModel);
        ObservableCollection<TopicModel> GetTopics();
        void AddNewTopic(TopicModel TopicModel);
    }
}
