using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NoteForYou.Model
{
    public class ListNote : Note
    {
        public ObservableCollection<SubNote> SubNotes { get; set; } = new ObservableCollection<SubNote>();

        public string Icon => "icon_listnote";
        public string IconColor => "icon_list_color";
    }

    public class SubNote : ObservableObject
    {
        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        public int ListNoteId { get; set; }
        public ListNote ListNote { get; set; }
    }
}
