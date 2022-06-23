using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.StoreService;
using UWP.Core.Helper;
using UWP.Core.Service;
using Windows.Services.Store;
using Windows.UI.Popups;

namespace NoteForYou.ViewModel
{
    public class GiftDialogViewModel : ServiceObservableObject
    {
        public GiftDialogViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService, IMessenger messengerService) : base(dataService, navigationService, dialogService, messengerService)
        {
            _storeContext = StoreContext.GetDefault();

            SetupItems();
        }

        private StoreContext _storeContext;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        public ObservableCollection<ItemDetails> Items { get; set; }
        public ItemDetails SelectedItem { get; set; }

        private async void SetupItems()
        {
            IsActive = true;

            Items = await StoreHelper.Default.GetManagedConsumables();
            OnPropertyChanged(nameof(Items));

            IsActive = false;
        }

        private RelayCommand _selectionChangedCommand;
        public RelayCommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand(() =>
        {
            DonateCommand.NotifyCanExecuteChanged();
        }));

        private RelayCommand _donateCommand;
        public RelayCommand DonateCommand => _donateCommand ?? (_donateCommand = new RelayCommand(async () =>
        {
            var result = await _storeContext.RequestPurchaseAsync(SelectedItem.StoreId);

            if (result.ExtendedError != null)
            {
                Debug.WriteLine(result.ExtendedError);
            }

            switch (result.Status)
            {
                case StorePurchaseStatus.AlreadyPurchased:
                    Debug.WriteLine($"You already bought this consumable and must fulfill it.");
                    break;

                case StorePurchaseStatus.Succeeded:
                    await new MessageDialog($"Thank you!").ShowAsync();
                    Debug.WriteLine($"You bought {SelectedItem.Title}.");
                    break;

                case StorePurchaseStatus.NotPurchased:

                    Debug.WriteLine("Product was not purchased, it may have been canceled.");
                    break;

                case StorePurchaseStatus.NetworkError:
                    await new MessageDialog($"Network Error").ShowAsync();
                    Debug.WriteLine("Product was not purchased due to a network error.");
                    break;

                case StorePurchaseStatus.ServerError:
                    Debug.WriteLine("Product was not purchased due to a server error.");
                    break;

                default:
                    Debug.WriteLine("Product was not purchased due to an unknown error.");
                    break;
            }
            
        }, () =>
        {
            return SelectedItem != null;
        }));

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
        {
            
        }));
    }
}
