using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.Core.Service;

namespace FocusTask.ViewModel
{
    public class SettingPageViewModel : ViewModelBase
    {
        public SettingPageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            SetupItems();

            IsPremium = StoreHelper.Default.IsPremium;
        }

        private ObservableCollection<ItemDetails> _items;
        public ObservableCollection<ItemDetails> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private bool _isPremium;
        public bool IsPremium
        {
            get { return _isPremium; }
            set { SetProperty(ref _isPremium, value); OnPropertyChanged(nameof(Premium)); }
        }

        public string Premium => IsPremium ? "Yes" : "No";

        public string SubcriptionPrice => StoreHelper.Default.subscriptionStorePrice;

        private void SetupItems()
        {
            var list = StoreHelper.Default.Consumables.OrderBy(x => x.Quantity);
            list.Reverse();

            Items = new ObservableCollection<ItemDetails>(list);

            string storeTestId = "9NGLN5CJ36LH";
            foreach (var item in Items)
            {
                if (storeTestId == item.StoreId)
                {
                    Items.Remove(item);
                    break;
                }
            }
        }

        private RelayCommand<ItemDetails> _purchaseCommand;
        public RelayCommand<ItemDetails> PurchaseCommand => _purchaseCommand ?? (_purchaseCommand = new RelayCommand<ItemDetails>(async (item) =>
        {
            await StoreHelper.Default.RequestPurchaseAsync(item);

            await StoreHelper.Default.UpdateConsumableBalance();

            OnPropertyChanged(nameof(Quantity));
        }));

        public uint Quantity => StoreHelper.Default.Balance;

        private RelayCommand _purchasePremiumCommand;
        public RelayCommand PurchasePremiumCommand => _purchasePremiumCommand ?? (_purchasePremiumCommand = new RelayCommand(async () =>
        {
            if (StoreHelper.Default.SubscriptionStoreProduct != null)
            {
                await StoreHelper.Default.RequestPurchaseSubcriptionAsync();
            }
        }));
    }
}
