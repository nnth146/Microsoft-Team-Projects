using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class FolderModel
    {
        public int FolderModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public enum ExplorerItemType { Folder };
        public ExplorerItemType Type { get; set; }
        public string Icon => "ms-appx:///Assets/Icon/Folder.png";

        public DateTime Create_On { get; set; }

        private ObservableCollection<StudyModel> _studyModels;
        public ObservableCollection<StudyModel> StudyModels
        {
            get
            {
                if (_studyModels == null)
                {
                    _studyModels = new ObservableCollection<StudyModel>();
                }
                return _studyModels;
            }
            set
            {
                _studyModels = value;
            }
        }

    }
}
