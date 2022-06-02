using System;
using System.Collections.Generic;
using System.Text;

namespace KeepSafeForPassword.Model
{
    public class Address : Password
    {
        private string _streetAddressLine1;
        public string StreetAddressLine1 { get { return _streetAddressLine1; } set { SetProperty(ref _streetAddressLine1, value); } }

        private string _streetAddressLine2;
        public string StreetAddressLine2 { get { return _streetAddressLine2; } set { SetProperty(ref _streetAddressLine2, value); } }

        private string _city;
        public string City { get { return _city; } set { SetProperty(ref _city, value); } }

        private string _stateProvince;
        public string StateProvince { get { return _stateProvince; } set { SetProperty(ref _stateProvince, value); } }

        private string _zipPostalCode;
        public string ZipPostalCode { get { return _zipPostalCode; } set { SetProperty(ref _zipPostalCode, value); } }

        private string _country;
        public string Country { get { return _country; } set { SetProperty(ref _country, value); } }

        public string Icon => "ms-appx:///Assets/Icons/icon_address.png";

        public string SubTitle => $"{City} {StateProvince} {Country}";

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public Address()
        {
            this.PropertyChanged += Address_PropertyChanged;
        }

        private void Address_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(City):
                case nameof(StateProvince):
                case nameof(Country):
                    OnPropertyChanged(nameof(SubTitle));
                    break;
            }
        }

        public void CopyFrom(Address password)
        {
            this.Title = password.Title;
            this.StreetAddressLine1 = password.StreetAddressLine1;
            this.StreetAddressLine2 = password.StreetAddressLine2;
            this.City = password.City;
            this.StateProvince = password.StateProvince;
            this.Country = password.Country;
        }
    }
}
