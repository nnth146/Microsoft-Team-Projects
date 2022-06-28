using System;
using System.Collections.ObjectModel;

namespace Uwp.SQLite.Model
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set; }
        public DateTime NoteDueDate { get; set; }
        private ObservableCollection<CheckList> _noteCheckLists { get; set; }
        public ObservableCollection<CheckList> NoteCheckLists
        {
            get
            {
                if (_noteCheckLists == null)
                {
                    _noteCheckLists = new ObservableCollection<CheckList>();
                }
                return _noteCheckLists;
            }
            set { _noteCheckLists = value; }
        }
        public int AmountStep { get; set; }
        public int StepCompleted { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime NoteCreate_On { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}
