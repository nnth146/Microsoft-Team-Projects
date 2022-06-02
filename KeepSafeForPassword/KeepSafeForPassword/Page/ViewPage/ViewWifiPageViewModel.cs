using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Core.Service;

namespace KeepSafeForPassword.ViewModel
{
    public class ViewWifiPageViewModel : ViewDatabasePageViewModel
    {
        public ViewWifiPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {

        }

        public new IEnumerable<Password> FilterPasswords { get; set; } = Account.CurrentAccount.Wifis;

        private RelayCommand _openAddSplitViewCommand;
        public new RelayCommand OpenAddSplitViewCommand => _openAddSplitViewCommand ?? (_openAddSplitViewCommand = new RelayCommand(() =>
        {
            var frame = messengerService.Send<AddPasswordFrameRequestMessage>().Response;
            //TODO
            navigationService.Navigate(frame, typeof(AddWifiPageViewModel));

            IsAddSplitViewOpen = !IsAddSplitViewOpen;
        }));
    }
}
