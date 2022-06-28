using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        private ObservableCollection<Folder> _planFolders { get; set; }
        public ObservableCollection<Folder> PlanFolders
        {
            get
            {
                if (_planFolders == null)
                {
                    _planFolders = new ObservableCollection<Folder>();
                }
                return _planFolders;
            }
            set { _planFolders = value; }
        }
        public DateTime PlanCreate_On { get; set; }
    }
}
