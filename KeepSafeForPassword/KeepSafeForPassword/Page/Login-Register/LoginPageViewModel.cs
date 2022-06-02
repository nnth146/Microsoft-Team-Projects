using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using UWP.Core.Helper;
using UWP.Core.Service;
using Windows.Storage;

namespace KeepSafeForPassword.ViewModel
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            Accounts = dataService.GetAccounts();
            messengerService.Register<RequireLogin>(this, (r, m) =>
            {
                Login();
            });
        }

        #region Xử lý đăng nhập

        public string Username { get; set; }
        public Validate ErrorOfUsername { get; set; } = new Validate();

        public string Password { get; set; }
        public Validate ErrorOfPassword { get; set; } = new Validate();
        
        public ObservableCollection<Account> Accounts { get; set; }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(() =>
        {
            ErrorOfUsername.CheckUsername(Username ?? "");
            ErrorOfPassword.CheckPassword(Password ?? "");

            bool isError = ErrorOfPassword.IsError || ErrorOfUsername.IsError;
            if (isError)
            {
                return;
            }

            foreach (var account in Accounts)
            {
                if(account.Username == Username && account.Password == Password)
                {
                    //Lưu giữ account hiện tại
                    Account.CurrentAccount = account;
                    ApplicationData.Current.LocalSettings.Values["CurrentAccountId"] = account.Id;

                    navigationService.Navigate(typeof(HomePageViewModel));
                    return;
                }
            }

            string errorOfWrongInformation = "Username or password is wrong";
            ErrorOfUsername.IsError = true;
            ErrorOfUsername.Error = errorOfWrongInformation;

        }));
        #endregion

        //Đăng ký
        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand => _registerCommand ?? (_registerCommand = new RelayCommand(() =>
        {
            navigationService.Navigate(typeof(RegisterPageViewModel));
        }));

        //Kiểm tra tiền đăng nhập.
        //Nếu đăng nhập trước đó mà chưa logout thì tiếp tục đăng nhập
        public void Login()
        {
            int? accountId = ApplicationData.Current.LocalSettings.Values["CurrentAccountId"] as int?;
            if (accountId.HasValue)
            {
                Account.CurrentAccount = Accounts.Where(x => x.Id == accountId).First() ;
                
                navigationService.Navigate(typeof(HomePageViewModel), null);
            }
        }
    }
}
