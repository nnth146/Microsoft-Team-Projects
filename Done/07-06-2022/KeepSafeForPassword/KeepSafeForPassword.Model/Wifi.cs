using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class Wifi : Password
    {
        private string _login;
        public string Login { get { return _login; } set { SetProperty(ref _login, value); } }

        private bool _isNoEncryption;
        public bool IsNoEncryption { get { return _isNoEncryption; } set { SetProperty(ref _isNoEncryption, value); } }

        private bool _isWep;
        public bool IsWep { get { return _isWep; } set { SetProperty(ref _isWep, value); } }

        private bool _isWap;
        public bool IsWap { get { return _isWap; } set { SetProperty(ref _isWap, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }

        private string _note;
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }

        public string SubTitle => Login;

        public string Icon => "ms-appx:///Assets/Icons/icon_wifi.png";

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public Wifi()
        {
            IsNoEncryption = true;
            IsWep = false;
            IsWap = false;
            this.PropertyChanged += Wifi_PropertyChanged;
        }

        private void Wifi_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Login):
                    OnPropertyChanged(nameof(SubTitle));
                    break;
            }
        }

        public void CopyFrom(Wifi password)
        {
            this.Title = password.Title;
            this.Login = password.Login;
            this.IsNoEncryption = password.IsNoEncryption;
            this.IsWap = password.IsWap;
            this.IsWep = password.IsWep;
            this.Password = password.Password;
            this.Note = password.Note;
        }
    }
}
