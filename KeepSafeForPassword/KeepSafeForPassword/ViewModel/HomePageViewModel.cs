using KeepSafeForPassword.Messenger;
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
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        //Thêm password
        public List<PasswordType> PasswordTypes { get; set; } = PasswordType.All;

        private RelayCommand<PasswordType> _passwordTypeSelectionChangedCommand;
        public RelayCommand<PasswordType> PasswordTypeSelectionChanged => _passwordTypeSelectionChangedCommand ?? (_passwordTypeSelectionChangedCommand = new RelayCommand<PasswordType>((selectedItem) =>
        {
            var frame = messengerService.Send<HomePageFrameRequestMessage>().Response;

            switch (selectedItem.Title)
            {
                case "Password":
                    navigationService.Navigate(frame, AddDatabasePageViewModel);
                    break;
            }
        }));

    }
}
