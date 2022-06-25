using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class Folder
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        private ObservableCollection<Note> _folderNotes { get; set; }
        public ObservableCollection<Note> FolderNotes
        {
            get
            {
                if (_folderNotes == null)
                {
                    _folderNotes = new ObservableCollection<Note>();
                }
                return _folderNotes;
            }
            set { _folderNotes = value; }
        }
        public DateTime FolderCreate_On { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
