using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace KeepSafeForPassword.ViewModel
{
    public class RegisterPageViewModel : ViewModelBase
    {
        public RegisterPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        #region Xử lý đăng ký

        private string _username;
        public string Username { get { return _username; } set { SetProperty(ref _username, value); } }
        public Validate ErrorOfUsername { get; set; } = new Validate();

        private string _password;
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }
        public Validate ErrorOfPassword { get; set; } = new Validate();

        private string _rePassword;
        public string RePassword { get { return _rePassword; } set { SetProperty(ref _rePassword, value); } }
        public Validate ErrorOfRePassword { get; set; } = new Validate();

        private RelayCommand _createAccountCommand;
        public RelayCommand CreateAccountCommand => _createAccountCommand ?? (_createAccountCommand = new RelayCommand(async () =>
        {

            ErrorOfUsername.CheckUsername(Username ?? "");
            ErrorOfPassword.CheckPassword(Password ?? "");
            ErrorOfRePassword.CheckPassword(RePassword ?? "");

            bool isError = ErrorOfPassword.IsError || ErrorOfRePassword.IsError || ErrorOfUsername.IsError;
            if (isError)
            {
                return;
            }

            string errorMessageOfSameValue = "Password and RePassword not same";
            if (Password != RePassword)
            {
                ErrorOfPassword.IsError = true;
                ErrorOfPassword.Error = errorMessageOfSameValue;
                ErrorOfRePassword.IsError = true;
                ErrorOfRePassword.Error = errorMessageOfSameValue;
                return;
            }
            
            Account account = new Account
            {
                Username = Username,
                Password = Password,
            };

            string successMessage = "Register success!";

            await dataService.AddAccountAsync(account);
            await dialogService.showMessageAsync(successMessage);
            
            navigationService.GoBack();
        }));
        #endregion

        private RelayCommand _backToLoginCommand;

        public RelayCommand BackToLoginCommand => _backToLoginCommand ?? (_backToLoginCommand = new RelayCommand(() =>
        {
            navigationService.GoBack();
        }));
    }
}
