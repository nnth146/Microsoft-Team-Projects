﻿using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace KeepSafeForPassword.ViewModel
{
    public class EditAddressPageViewModel : ViewModelBase
    {
        public EditAddressPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            SelectedPassword = messengerService.Send<SelectedPasswordRequestMessage>().Response as Address;
            Password = new Address();
            Password.CopyFrom(SelectedPassword);
        }

        #region Xử lý random password

        public RandomPassword RandomPassword { get; set; } = new RandomPassword();

        private RelayCommand _randomPasswordCommand;
        public RelayCommand RandomPasswordCommand => _randomPasswordCommand ?? (_randomPasswordCommand = new RelayCommand(() =>
        {
            
        }));

        #endregion

        #region Xử lý lưu Password

        private Address _password;
        public Address Password { get { return _password; } set { SetProperty(ref _password, value); } }

        public Address SelectedPassword { get; set; }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(() =>
        {
            if (!string.IsNullOrEmpty(Password.Title))
            {
                SelectedPassword.CopyFrom(Password);
                messengerService.Send<EditCommandRequestMessage>().Response.Execute(null);
            }

        }));
        #endregion
    }
}
