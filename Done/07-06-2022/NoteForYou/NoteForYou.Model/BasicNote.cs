using System;
using System.Collections.Generic;
using System.Text;

namespace NoteForYou.Model
{
    public class BasicNote : Note
    {
        private string _note;
        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }

        public string Icon => "icon_note";
        public string IconColor => "icon_note_color";
    }
}
