using System;
using System.Collections.Generic;
using System.Text;

namespace NoteForYou.Model
{
    public class SecureNote : Note
    {
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private string _note;
        public string Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }

        public string Icon => "icon_securenote";
        public string IconColor => "icon_securenote_color";
    }
}
