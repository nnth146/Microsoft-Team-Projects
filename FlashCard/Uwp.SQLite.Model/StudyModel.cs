using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class StudyModel
    {
        public int StudyModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public enum ExplorerItemType { File };
        public ExplorerItemType Type { get; set; }
        public string Icon => "ms-appx:///Assets/Icon/File.png";

        public DateTime Create_On { get; set; }

        public int FolderModelId { get; set; }
        public FolderModel FolderModel { get; set; }

        private ObservableCollection<TopicModel> _topicModels;
        public ObservableCollection<TopicModel> TopicModels
        {
            get
            {
                if (_topicModels == null)
                {
                    _topicModels = new ObservableCollection<TopicModel>();
                }
                return _topicModels;
            }
            set
            {
                _topicModels = value;
            }
        }
    }
}
