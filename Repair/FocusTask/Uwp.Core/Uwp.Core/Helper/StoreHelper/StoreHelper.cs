using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Controls;
using Windows.Services.Store;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Uwp.Core.Helper
{
    public class StoreHelper
    {
        public StoreHelper()
        {
            _storeContext = StoreContext.GetDefault();
        }

        private StoreContext _storeContext;
        private static readonly StoreHelper _instance = new StoreHelper();
        public static StoreHelper Default => _instance;

        readonly MessageContentDialog messageDialog = new MessageContentDialog();

        #region Xử lý chung

        public async Task Initiliaze()
        {
            Consumables = await GetManagedConsumables();

            await UpdateConsumableBalance();

            await SetupSubscriptionInfoAsync();
        }

        public async Task RequestPurchaseAsync(ItemDetails item)
        {
            StorePurchaseResult result = await _storeContext.RequestPurchaseAsync(item.StoreId);

            if (result.ExtendedError != null)
            {
                await messageDialog.ShowMessageAsync(result.ExtendedError.Message);
                return;
            }

            string message;

            switch (result.Status)
            {
                case StorePurchaseStatus.AlreadyPurchased:
                    message = "Already Purchased!";
                    await messageDialog.ShowMessageAsync(message);
                    break;
                case StorePurchaseStatus.Succeeded:
                    message = "Thank you very much!. Please wait a few minutes for the update ";
                    await messageDialog.ShowMessageAsync(message);
                    break;
                case StorePurchaseStatus.NetworkError:
                    message = "Network Error!";
                    await messageDialog.ShowMessageAsync(message);
                    break;
                case StorePurchaseStatus.ServerError:
                    message = "Server Error!";
                    await messageDialog.ShowMessageAsync(message);
                    break;
                case StorePurchaseStatus.NotPurchased:
                    break;
            }
        }

        #endregion

        #region Xử lý consumable

        //Item Consumables
        public ObservableCollection<ItemDetails> Consumables = new ObservableCollection<ItemDetails>();

        //Số lượng còn lại
        public uint Balance = 0;

        public async Task UpdateConsumableBalance()
        {
            uint balance = 0;
            foreach (var item in Consumables)
            {
                var storeConsumableResult = await _storeContext.GetConsumableBalanceRemainingAsync(item.StoreId);
                if (storeConsumableResult.ExtendedError != null)
                {
                    continue;
                }
                switch (storeConsumableResult.Status)
                {
                    case StoreConsumableStatus.InsufficentQuantity:
                        continue;
                    case StoreConsumableStatus.Succeeded:
                        balance += storeConsumableResult.BalanceRemaining;
                        continue;
                    case StoreConsumableStatus.NetworkError:
                        string errorNetwork = "Can't get available add on becasuse network error! please check network and try again";
                        await messageDialog.ShowMessageAsync(errorNetwork);
                        break;
                    case StoreConsumableStatus.ServerError:
                        string errorServer = "Can't get available add on becasuse server error! please check network and try again";
                        await messageDialog.ShowMessageAsync(errorServer);
                        break;
                }
            }

            Balance = balance;
        }

        public async void FulfillConsumable()
        {
            if (_storeContext == null)
            {
                _storeContext = StoreContext.GetDefault();
                // If your app is a desktop app that uses the Desktop Bridge, you
                // may need additional code to configure the StoreContext object.
                // For more info, see https://aka.ms/storecontext-for-desktop.
            }

            uint quantity = 1;

            Guid trackingId = Guid.NewGuid();

            StoreConsumableResult result;

            foreach (var item in Consumables)
            {
                result = await _storeContext.ReportConsumableFulfillmentAsync(item.StoreId, quantity, trackingId);
                switch (result.Status)
                {
                    case StoreConsumableStatus.Succeeded:
                        await UpdateConsumableBalance();
                        break;

                    case StoreConsumableStatus.InsufficentQuantity:
                        continue;

                    case StoreConsumableStatus.NetworkError:
                        string errorNetwork = "Network Error!";
                        await messageDialog.ShowMessageAsync(errorNetwork);
                        break;

                    case StoreConsumableStatus.ServerError:
                        string errorServer = "Server Error!";
                        await messageDialog.ShowMessageAsync(errorServer);
                        break;
                }
            }
        }

        #endregion

        #region Xử lý subcription

        public string SubscriptionStoreId = "9PG40QW4F1LW";
        public StoreProduct SubscriptionStoreProduct;

        public bool IsPremium = false;

        //Giá subscription
        public string subscriptionStorePrice;

        //Ngày hết hạn
        public DateTimeOffset ExpirationDate;



        public async Task RequestPurchaseSubcriptionAsync()
        {
            await PromptUserToPurchaseAsync();
        }

        public async Task SetupSubscriptionInfoAsync()
        {
            if (_storeContext == null)
            {
                _storeContext = StoreContext.GetDefault();
                // If your app is a desktop app that uses the Desktop Bridge, you
                // may need additional code to configure the StoreContext object.
                // For more info, see https://aka.ms/storecontext-for-desktop.
            }
            bool userOwnsSubscription = await CheckIfUserHasSubscriptionAsync();
            if (userOwnsSubscription)
            {
                // Unlock all the subscription add-on features here.
                IsPremium = true;
                return;
            }

            // Get the StoreProduct that represents the subscription add-on.
            SubscriptionStoreProduct = await GetSubscriptionProductAsync();
            if (SubscriptionStoreProduct == null)
            {
                return;
            }

            // Check if the first SKU is a trial and notify the customer that a trial is available.
            // If a trial is available, the Skus array will always have 2 purchasable SKUs and the
            // first one is the trial. Otherwise, this array will only have one SKU.
            StoreSku sku = SubscriptionStoreProduct.Skus[0];
            if (sku.SubscriptionInfo.HasTrialPeriod)
            {
                // You can display the subscription trial info to the customer here. You can use 
                // sku.SubscriptionInfo.TrialPeriod and sku.SubscriptionInfo.TrialPeriodUnit 
                // to get the trial details.
                subscriptionStorePrice = SubscriptionStoreProduct.Skus[1].Price.FormattedPrice;
            }
            else
            {
                // You can display the subscription purchase info to the customer here. You can use 
                // sku.SubscriptionInfo.BillingPeriod and sku.SubscriptionInfo.BillingPeriodUnit
                // to provide the renewal details.
                subscriptionStorePrice = sku.Price.FormattedPrice;
            }

            // Prompt the customer to purchase the subscription.
        }

        private async Task<bool> CheckIfUserHasSubscriptionAsync()
        {
            StoreAppLicense appLicense = await _storeContext.GetAppLicenseAsync();

            // Check if the customer has the rights to the subscription.
            foreach (var addOnLicense in appLicense.AddOnLicenses)
            {
                StoreLicense license = addOnLicense.Value;
                if (license.SkuStoreId.StartsWith(SubscriptionStoreId))
                {
                    if (license.IsActive)
                    {
                        // The expiration date is available in the license.ExpirationDate property.
                        ExpirationDate = license.ExpirationDate;

                        return true;
                    }
                }
            }

            // The customer does not have a license to the subscription.
            return false;
        }

        private async Task<StoreProduct> GetSubscriptionProductAsync()
        {
            // Load the sellable add-ons for this app and check if the trial is still 
            // available for this customer. If they previously acquired a trial they won't 
            // be able to get a trial again, and the StoreProduct.Skus property will 
            // only contain one SKU.
            StoreProductQueryResult result =
                await _storeContext.GetAssociatedStoreProductsAsync(new string[] { "Durable" });

            if (result.ExtendedError != null)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong while getting the add-ons. " +
                    "ExtendedError:" + result.ExtendedError);
                return null;
            }

            // Look for the product that represents the subscription.
            foreach (var item in result.Products)
            {
                StoreProduct product = item.Value;
                if (product.StoreId == SubscriptionStoreId)
                {
                    return product;
                }
            }

            System.Diagnostics.Debug.WriteLine("The subscription was not found.");
            return null;
        }

        private async Task PromptUserToPurchaseAsync()
        {
            // Request a purchase of the subscription product. If a trial is available it will be offered 
            // to the customer. Otherwise, the non-trial SKU will be offered.
            StorePurchaseResult result = await SubscriptionStoreProduct.RequestPurchaseAsync();

            // Capture the error message for the operation, if any.
            string extendedError = string.Empty;
            if (result.ExtendedError != null)
            {
                extendedError = result.ExtendedError.Message;
            }

            switch (result.Status)
            {
                case StorePurchaseStatus.Succeeded:
                    // Show a UI to acknowledge that the customer has purchased your subscription 
                    // and unlock the features of the subscription. 
                    IsPremium = true;
                    break;

                case StorePurchaseStatus.NotPurchased:
                    string errorPurchase = "The purchase did not complete. " +
                        "The customer may have cancelled the purchase. ExtendedError: " + extendedError;
                    await new MessageDialog(errorPurchase).ShowAsync();
                    break;

                case StorePurchaseStatus.ServerError:
                case StorePurchaseStatus.NetworkError:
                    string errorNetwork = "The purchase was unsuccessful due to a server or network error. " +
                        "ExtendedError: " + extendedError;
                    await new MessageDialog(errorNetwork).ShowAsync();
                    break;

                case StorePurchaseStatus.AlreadyPurchased:
                    System.Diagnostics.Debug.WriteLine("The customer already owns this subscription. " +
                            "ExtendedError: " + extendedError);
                    string errorAlreadyPurchased = "The customer already owns this subscription. " +
                            "ExtendedError: " + extendedError;
                    await new MessageDialog(errorAlreadyPurchased).ShowAsync();
                    break;
            }
        }
        #endregion



        #region Hướng dẫn cơ bản
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

        public async Task FulfillConsumable(ItemDetails item, UInt32 quantity)
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
        #endregion
    }
}
