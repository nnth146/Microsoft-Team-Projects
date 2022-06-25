using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class CheckList
    {
        public int CheckListId { get; set; }
        public string CheckListName { get; set; }
        private ObservableCollection<Step> _checkListSteps { get; set; }
        public ObservableCollection<Step> CheckListSteps
        {
            get
            {
                if (_checkListSteps == null)
                {
                    _checkListSteps = new ObservableCollection<Step>();
                }
                return _checkListSteps;
            }
            set
            {
                _checkListSteps = value;
            }
        }
        public DateTime CheckListCreate_On { get; set; }
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
