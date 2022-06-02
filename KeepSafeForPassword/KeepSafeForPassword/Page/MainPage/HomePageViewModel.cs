using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Helper;
using UWP.Core.Service;
using Windows.Storage;

namespace KeepSafeForPassword.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            Passwords = dataService.GetPasswords();
            Passwords.CollectionChanged += Passwords_CollectionChanged;

            SetUpNavViews();

            RegisterMessage();
        }

        private void RegisterMessage()
        {
            messengerService.Register<PasswordsRequestMessage>(this, (r, m) =>
            {
                m.Reply(Passwords);
            });
        }

        #region Xử lý update dữ liệu
        private void Passwords_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                dataService.AddPassword(e.NewItems[0] as Password);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                dataService.RemovePassword(e.OldItems[0] as Password);
            }
        }
        #endregion

        #region Xử lý cho navigation
        public List<NavViewItem> NavViews { get; set; }

        public ObservableCollection<Password> Passwords { get; set; }

        private void SetUpNavViews()
        {
            NavViews = new List<NavViewItem>()
            {
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_password.png",
                    Title = "All Password",
                    Passwords = Passwords,
                },
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_address.png",
                    Title = "Address",
                    Passwords = Account.Address,
                },
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_contact.png",
                    Title = "Contact",
                    Passwords = Account.Contacts
                },
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_database.png",
                    Title = "Database",
                    Passwords = Account.Databases,
                },
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_secure_note.png",
                    Title = "Secure Note",
                    Passwords = Account.SecureNotes,
                },
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_server.png",
                    Title = "Server",
                    Passwords = Account.Server,
                },
                new NavViewItem
                {
                    Icon = "ms-appx:///Assets/Icons/icon_wifi.png",
                    Title = "Wifi",
                    Passwords = Account.Wifis
                },
            };
        }
        #endregion

        #region Xử lý Account

        public Account Account { get; set; } = Account.CurrentAccount;

        //Logout
        private RelayCommand _logOutCommand;
        public RelayCommand LogOutCommand => _logOutCommand ?? (_logOutCommand = new RelayCommand(() =>
        {
            Account.CurrentAccount = null;
            ApplicationData.Current.LocalSettings.Values["CurrentAccountId"] = null;

            navigationService.GoBack();
        }));
        
        //Xoá account
        private RelayCommand _deleteAccountCommand;
        public RelayCommand DeleteAccountCommand => _deleteAccountCommand ?? (_deleteAccountCommand = new RelayCommand(async () =>
        {
            string message = "Are you sure about deleting this Account";

            await dialogService.showQuestionDialogAsync(message, ComfirmDeleteAccountCommand);
        }));

        private RelayCommand _comfirmDeleteAccountCommand;
        public RelayCommand ComfirmDeleteAccountCommand => _comfirmDeleteAccountCommand ?? (_comfirmDeleteAccountCommand = new RelayCommand(async () =>
        {
            await dataService.RemoveAccountAsync(Account);

            LogOutCommand.Execute(null);
        }));
        #endregion
    }
}
