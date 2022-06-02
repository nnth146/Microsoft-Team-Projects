using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class CommonPassword : Password
    {
        private string _login;
        public string Login { get { return _login; } set { SetProperty(ref _login, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }

        private string _website;
        public string Website { get { return _website; } set { SetProperty(ref _website, value); } }

        private string _note;
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }

        public string Icon => "ms-appx:///Assets/Icons/icon_password.png";

        public string SubTitle => Website;

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public CommonPassword()
        {
            this.PropertyChanged += CommonPassword_PropertyChanged;
        }

        private void CommonPassword_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Website):
                    OnPropertyChanged(nameof(SubTitle));
                    break;
            }
        }

        public void CopyFrom(CommonPassword password)
        {
            this.Title = password.Title;
            this.Login = password.Login;
            this.Password = password.Password;
            this.Website = password.Website;
            this.Note = password.Note;
        }
    }
}
