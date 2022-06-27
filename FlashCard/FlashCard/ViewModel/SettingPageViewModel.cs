using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;

namespace FlashCard.ViewModel
{
    public class SettingPageViewModel : ViewModelBase
    {
        public SettingPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {

        }

        public string SubscriptionStorePrice => StoreHelper.Default.SubscriptionStorePrice;

        public string UnlockUnlimitedStatus => StoreHelper.Default.IsUnlockAllFeatures ? "Yes" : "No";

        private RelayCommand _requestPurchaseCommand;
        public RelayCommand RequestPurchaseCommand => _requestPurchaseCommand ?? (_requestPurchaseCommand = new RelayCommand(async () =>
        {
            if(StoreHelper.Default.SubscriptionStoreProduct != null)
            {
                await StoreHelper.Default.RequestPurchaseSubscriptionAsync();
            }
        }));
    }
}
