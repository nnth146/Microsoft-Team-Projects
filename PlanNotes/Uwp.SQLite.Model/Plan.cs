using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        private ObservableCollection<Folder> _planFolder { get; set; }
        public ObservableCollection<Folder> PlanFolder
        {
            get
            {
                if (_planFolder == null)
                {
                    _planFolder = new ObservableCollection<Folder>();
                }
                return _planFolder;
            }
            set { _planFolder = value; }
        }
        public DateTime PlanCreate_On { get; set; }
    }
}
