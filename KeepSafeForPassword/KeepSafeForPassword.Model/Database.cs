using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class Database : Password
    {
        private string _type;
        public string Type { get { return _type; } set { SetProperty(ref _type, value); } }

        private string _hostName;
        public string HostName { get { return _hostName; } set { SetProperty(ref _hostName, value); } }

        private string _post;
        public string Post { get { return _post; } set { SetProperty(ref _post, value); } }

        private string _login;
        public string Login { get { return _login; } set { SetProperty(ref _login, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }

        private string _note;
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }

        public string Icon => "ms-appx:///Assets/Icons/icon_database.png";

        public string SubTitle => HostName;

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public Database()
        {
            this.PropertyChanged += Database_PropertyChanged;
        }

        private void Database_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(HostName):
                    OnPropertyChanged(nameof(SubTitle));
                    break;
            }
        }

        public void CopyFrom(Database password)
        {
            this.Title = password.Title;
            this.Type = password.Type;
            this.HostName = password.HostName;
            this.Post = password.Post;
            this.Login = password.Login;
            this.Password = password.Password;
            this.Note = password.Note;
        }
    }
}
