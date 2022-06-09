using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Store;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Core.StoreService
{
    public class StoreHelper
    {
        public StoreHelper()
        {
            _storeContext = StoreContext.GetDefault();
        }
        private StoreContext _storeContext;
        private static StoreHelper _instance = new StoreHelper();
        public static StoreHelper Default => _instance;

        public ObservableCollection<ItemDetails>
            CreateProductListFromQueryResult(StoreProductQueryResult addOns, string description)
        {
            var productList = new ObservableCollection<ItemDetails>();

            if (addOns.ExtendedError != null)
            {
                Debug.WriteLine(addOns.ExtendedError);
            }
            else if (addOns.Products.Count == 0)
            {
                Debug.WriteLine($"No configured {description} found for this Store Product.");
            }
            else
            {
                foreach (StoreProduct product in addOns.Products.Values)
                {
                    productList.Add(new ItemDetails(product));
                }
            }
            return productList;
        }

        public async Task GetLicenseState()
        {
            StoreAppLicense license = await _storeContext.GetAppLicenseAsync();

            if (license.IsActive)
            {
                if (license.IsTrial)
                {
                    Debug.WriteLine("Trial license");
                }
                else
                {
                    Debug.WriteLine("Full license");
                }
            }
            else
            {
                Debug.WriteLine("Inactive license");
            }
        }

        public async void ShowTrialPeriodInformation()
        {
            StoreAppLicense license = await _storeContext.GetAppLicenseAsync();
            if (license.IsActive)
            {
                if (license.IsTrial)
                {
                    int remainingTrialTime = (license.ExpirationDate - DateTime.Now).Days;
                    Debug.WriteLine($"You can use this app for {remainingTrialTime} more days before the trial period ends.");
                }
                else
                {
                    Debug.WriteLine("You have a full license. The trial time is not meaningful.");
                }
            }
            else
            {
                Debug.WriteLine("You don't have a license. The trial time can't be determined.");
            }
        }

        public async void PurchaseFullLicense()
        {
            // Get app store product details
            StoreProductResult productResult = await _storeContext.GetStoreProductForCurrentAppAsync();
            if (productResult.ExtendedError != null)
            {
                // The user may be offline or there might be some other server failure
                Debug.WriteLine($"ExtendedError: {productResult.ExtendedError.Message}");
                return;
            }

            Debug.WriteLine("Buying the full license...");
            StoreAppLicense license = await _storeContext.GetAppLicenseAsync();
            if (license.IsTrial)
            {
                StorePurchaseResult result = await productResult.Product.RequestPurchaseAsync();
                if (result.ExtendedError != null)
                {
                    Debug.WriteLine($"Purchase failed: ExtendedError: {result.ExtendedError.Message}");
                    return;
                }

                switch (result.Status)
                {
                    case StorePurchaseStatus.AlreadyPurchased:
                        Debug.WriteLine($"You already bought this app and have a fully-licensed version.");
                        break;

                    case StorePurchaseStatus.Succeeded:
                        // License will refresh automatically using the StoreContext.OfflineLicensesChanged event
                        break;

                    case StorePurchaseStatus.NotPurchased:
                        Debug.WriteLine("Product was not purchased, it may have been canceled.");
                        break;

                    case StorePurchaseStatus.NetworkError:
                        Debug.WriteLine("Product was not purchased due to a Network Error.");
                        break;

                    case StorePurchaseStatus.ServerError:
                        Debug.WriteLine("Product was not purchased due to a Server Error.");
                        break;

                    default:
                        Debug.WriteLine("Product was not purchased due to an Unknown Error.");
                        break;
                }
            }
            else
            {
                Debug.WriteLine("You already bought this app and have a fully-licensed version.");
            }
        }

        public async Task<ObservableCollection<ItemDetails>> GetUnmanagedConsumables()
        {
            string[] filterList = new string[] { "UnmanagedConsumable" };

            // Get list of Add Ons this app can sell, filtering for the types we know about.
            StoreProductQueryResult addOns = await _storeContext.GetAssociatedStoreProductsAsync(filterList);

            return CreateProductListFromQueryResult(addOns, "UnmanagedConsumable Add-Ons");
        }

        public async Task<StorePurchaseResult> PurchaseAddOn(ItemDetails item)
        {
            var result = await _storeContext.RequestPurchaseAsync(item.StoreId);
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
                    Debug.WriteLine($"You bought {item.Title}.");
                    break;

                case StorePurchaseStatus.NotPurchased:
                    Debug.WriteLine("Product was not purchased, it may have been canceled.");
                    break;

                case StorePurchaseStatus.NetworkError:
                    Debug.WriteLine("Product was not purchased due to a network error.");
                    break;

                case StorePurchaseStatus.ServerError:
                    Debug.WriteLine("Product was not purchased due to a server error.");
                    break;

                default:
                    Debug.WriteLine("Product was not purchased due to an unknown error.");
                    break;
            }
            return result;
        }
        
        public async void GetConsumableBalance(ItemDetails item)
        {
            StoreConsumableResult result = await _storeContext.GetConsumableBalanceRemainingAsync(item.StoreId);
            if (result.ExtendedError != null)
            {
                Debug.WriteLine(result.ExtendedError);
                return;
            }

            switch (result.Status)
            {
                case StoreConsumableStatus.InsufficentQuantity: // should never get this...
                    Debug.WriteLine($"Insufficient Quantity! Balance Remaining: {result.BalanceRemaining}");
                    break;

                case StoreConsumableStatus.Succeeded:
                    Debug.WriteLine($"Balance Remaining: {result.BalanceRemaining}");
                    break;

                case StoreConsumableStatus.NetworkError:
                    Debug.WriteLine("Network error retrieving consumable balance.");
                    break;

                case StoreConsumableStatus.ServerError:
                    Debug.WriteLine("Server error retrieving consumable balance.");
                    break;

                default:
                    Debug.WriteLine("Unknown error retrieving consumable balance.");
                    break;
            }
        }
        //Unmanage
        public async void FulfillConsumable(ItemDetails item, UInt32 quantity)
        {
            // This can be used to ensure this request is never double fulfilled. The server will
            // accept only one report for this specific GUID.
            Guid trackingId = Guid.NewGuid();

            // Always use quantity of "1" to fulfill an Unmanaged consumable
            StoreConsumableResult result = await _storeContext.ReportConsumableFulfillmentAsync(item.StoreId, quantity, trackingId);
            if (result.ExtendedError != null)
            {
                Debug.WriteLine(result.ExtendedError);
                return;
            }

            switch (result.Status)
            {
                case StoreConsumableStatus.InsufficentQuantity:
                    Debug.WriteLine($"Insufficient Quantity! Balance Remaining: {result.BalanceRemaining}");
                    break;

                case StoreConsumableStatus.Succeeded:
                    Debug.WriteLine($"Successful fulfillment! Balance Remaining: {result.BalanceRemaining}");
                    break;

                case StoreConsumableStatus.NetworkError:
                    Debug.WriteLine("Network error fulfilling consumable.");
                    break;

                case StoreConsumableStatus.ServerError:
                    Debug.WriteLine("Server error fulfilling consumable.");
                    break;

                default:
                    Debug.WriteLine("Unknown error fulfilling consumable.");
                    break;
            }
        }

        public async Task<ObservableCollection<ItemDetails>> GetManagedConsumables()
        {
            // Create a filtered list of the product AddOns I care about
            string[] filterList = new string[] { "Consumable" };

            // Get list of Add Ons this app can sell, filtering for the types we know about
            StoreProductQueryResult addOns = await _storeContext.GetAssociatedStoreProductsAsync(filterList);

            return CreateProductListFromQueryResult(addOns, "Consumable Add-Ons");
        }

        public async Task<ObservableCollection<ItemDetails>> GetUserCollection()
        {
            // Create a filtered list of the product AddOns I care about
            string[] filterList = new string[] { "Consumable", "Durable", "UnmanagedConsumable" };

            // Get user collection for this product, filtering for the types we know about
            StoreProductQueryResult collection = await _storeContext.GetUserCollectionAsync(filterList);

            return CreateProductListFromQueryResult(collection, "collection items");
        }

        public async Task<ObservableCollection<ItemDetails>> GetSubscriptions()
        {
            string[] filterList = new string[] { "Durable" };
            StoreProductQueryResult addOns = await _storeContext.GetAssociatedStoreProductsAsync(filterList);
            return CreateProductListFromQueryResult(addOns, "Subscription Add-Ons");
        }
        public async Task<ObservableCollection<ItemDetails>> GetUserSubcriptionsCollection()
        {
            // Create a filtered list of the product AddOns I care about
            string[] filterList = new string[] { "Durable" };

            // Get user collection for this product, filtering for the types we know about
            StoreProductQueryResult collection = await _storeContext.GetUserCollectionAsync(filterList);

            return CreateProductListFromQueryResult(collection, "collection items");
        }
        /* Sử dụng trong page
         private void OfflineLicensesChanged(StoreContext sender, object args)
        {
            var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                await GetLicenseState();
            });
        }
         */
    }
}
