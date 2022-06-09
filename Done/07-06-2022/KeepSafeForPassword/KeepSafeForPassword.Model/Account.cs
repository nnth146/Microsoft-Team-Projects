using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class Account : ObservableObject
    {
        //Lưu giữ account được đăng nhập
        public static Account CurrentAccount { get; set; }

        public int Id { get; set; }

        private string _username;
        public string Username { get { return _username; } set { SetProperty(ref _username, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }

        public ObservableCollection<CommonPassword> Passwords { get; set; } = new ObservableCollection<CommonPassword>();

        public ObservableCollection<Address> Address { get; set; } = new ObservableCollection<Address>();

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public ObservableCollection<Database> Databases { get; set; } = new ObservableCollection<Database>();

        public ObservableCollection<SecureNote> SecureNotes { get; set; } = new ObservableCollection<SecureNote>();

        public ObservableCollection<Server> Server { get; set; } = new ObservableCollection<Server>();

        public ObservableCollection<Wifi> Wifis { get; set; } = new ObservableCollection<Wifi>();
    }
}
