using System;
using System.Collections.Generic;
using System.Text;

namespace NoteForYou.Model
{
    public class AddressNote : Note
    {
        private string _streetAddressLine1;
        public string StreetAddressLine1
        {
            get { return _streetAddressLine1; }
            set { SetProperty(ref _streetAddressLine1, value); }
        }
        private string _streetAddressLine2;
        public string StreetAddressLine2
        {
            get { return _streetAddressLine2; }
            set { SetProperty(ref _streetAddressLine2, value); }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }
        private string _stateProvince;
        public string StateProvince
        {
            get { return _stateProvince; }
            set { SetProperty(ref _stateProvince, value); }
        }
        private string _zipPostalCode;
        public string ZipPostalCode
        {
            get { return _zipPostalCode; }
            set { SetProperty(ref _zipPostalCode, value); }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        public string Icon => "icon_address";
        public string IconColor => "icon_address_color";
    }
}
