using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using UWP.Core.Helper;
using UWP.Core.Service;

namespace KeepSafeForPassword.ViewModel
{
    public class AddPasswordPageViewModel : ViewModelBase
    {
        public AddPasswordPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            Password = new CommonPassword
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

        private CommonPassword _password;
        public CommonPassword Password { get { return _password; } set { SetProperty(ref _password, value); } }

        private RelayCommand<Password> _addCommand;
        public RelayCommand<Password> AddCommand => _addCommand ?? (_addCommand = new RelayCommand<Password>((addedPassword) =>
        {
            if (!string.IsNullOrEmpty(addedPassword.Title))
            {
                addedPassword.CreatedOn = DateTime.Now;
                messengerService.Send<AddCommandRequestMessage>().Response?.Execute(addedPassword);

                //Reset lại các trường
                Password = new CommonPassword
                {
                    AccountId = Account.CurrentAccount.Id,
                };
            }
        }));
        #endregion
    }
}
