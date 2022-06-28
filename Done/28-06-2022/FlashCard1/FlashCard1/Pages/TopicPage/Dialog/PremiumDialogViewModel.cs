using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;

namespace FlashCard1.Pages.TopicPage.Dialog
{
    public class PremiumDialogViewModel
    {

        public PremiumDialogViewModel()
        {

        }

        public string SubscriptionProductPrice => StoreHelper.Default.SubscriptionStorePrice + "/year";

        private RelayCommand _purchaseCommand;
        public RelayCommand PurchaseCommand => _purchaseCommand ?? (_purchaseCommand = new RelayCommand(async () =>
        {
            if(StoreHelper.Default.SubscriptionStoreProduct != null)
            {
                await StoreHelper.Default.RequestPurchaseSubscriptionAsync();
            }
        }));
    }
}
