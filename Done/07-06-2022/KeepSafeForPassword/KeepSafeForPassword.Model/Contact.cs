using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class Contact : Password
    {
        private string _firstName;
        public string FirstName { get { return _firstName; } set { SetProperty(ref _firstName, value); } }

        private string _middleName;
        public string MiddleName { get { return _middleName; } set { SetProperty(ref _middleName, value); } }

        private string _lastName;
        public string LastName { get { return _lastName; } set { SetProperty(ref _lastName, value); } }

        private string _company;
        public string Company { get { return _company; } set { SetProperty(ref _company, value); } }

        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        private string _phone;
        public string Phone { get { return _phone; } set { SetProperty(ref _phone, value); } }

        private string _note;
        public string Note { get { return _note; } set { SetProperty(ref _note, value); } }

        public string Icon => "ms-appx:///Assets/Icons/icon_contact.png";

        public string SubTitle => Email;

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public Contact()
        {
            this.PropertyChanged += Contact_PropertyChanged;
        }

        private void Contact_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Email):
                    OnPropertyChanged(nameof(SubTitle));
                    break;
            }
        }

        public void CopyFrom(Contact password)
        {
            this.Title = password.Title;
            this.FirstName = password.FirstName;
            this.MiddleName = password.MiddleName;
            this.LastName = password.LastName;
            this.Email = password.Email;
            this.Phone = password.Phone;
            this.Note = password.Note;
        }
    }
}
