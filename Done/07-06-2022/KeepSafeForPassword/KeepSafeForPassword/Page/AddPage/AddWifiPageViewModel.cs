using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace KeepSafeForPassword.ViewModel
{
    public class AddWifiPageViewModel : ViewModelBase
    {
        public AddWifiPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            Password = new Wifi
            {
                AccountId = Account.CurrentAccount.Id,
            };
        }

        #region Xử lý random password

        public RandomPassword RandomPassword { get; set; } = new RandomPassword();

        private RelayCommand _randomPasswordCommand;
        public RelayCommand RandomPasswordCommand => _randomPasswordCommand ?? (_randomPasswordCommand = new RelayCommand(() =>
        {
            Password.Password = RandomPassword.Random();
        }));

        #endregion

        #region Xử lý thêm Password

        private Wifi _password;
        public Wifi Password { get { return _password; } set { SetProperty(ref _password, value); } }

        private RelayCommand<Password> _addCommand;
        public RelayCommand<Password> AddCommand => _addCommand ?? (_addCommand = new RelayCommand<Password>((addedPassword) =>
        {
            if (!string.IsNullOrEmpty(addedPassword.Title))
            {
                addedPassword.CreatedOn = DateTime.Now;
                var added = addedPassword as Wifi;
                Debug.WriteLine(added.IsNoEncryption);
                Debug.WriteLine(added.IsWap);
                Debug.WriteLine(added.IsWep);
                messengerService.Send<AddCommandRequestMessage>().Response?.Execute(addedPassword);

                //Reset lại các trường
                Password = new Wifi
                {
                    AccountId = Account.CurrentAccount.Id,
                };
            }
        }));
        #endregion

    }
}
