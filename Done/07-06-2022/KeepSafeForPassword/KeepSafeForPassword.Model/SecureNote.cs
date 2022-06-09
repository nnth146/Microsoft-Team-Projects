using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class SecureNote : Password
    {
        private string _secureNote;
        public string SecureNoteAttribute { get { return _secureNote; } set { SetProperty(ref _secureNote, value); } }

        private DateTime _date;
        public DateTime Date { get { return _date; } set { SetProperty(ref _date, value); } }

        private string _note;
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }

        public string Icon => "ms-appx:///Assets/Icons/icon_secure_note.png";

        public string SubTitle => Note;

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public SecureNote()
        {
            this.PropertyChanged += SecureNote_PropertyChanged;
        }

        private void SecureNote_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Note):
                    OnPropertyChanged(nameof(SubTitle));
                    break;
            }
        }

        public void CopyFrom(SecureNote password)
        {
            this.Title = password.Title;
            this.SecureNoteAttribute = password.SecureNoteAttribute;
            this.Date = password.Date;
            this.Note = password.Note;
        }
    }
}
