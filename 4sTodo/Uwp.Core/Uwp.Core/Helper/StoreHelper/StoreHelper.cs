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
    public sealed class StoreHelper
    {
        private static StoreHelper _instance = new StoreHelper();
        public static StoreHelper Default => _instance;

        private StoreContext _context = StoreContext.GetDefault();
        public StoreContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        private const string _consumableAddOnKind = "Consumable";
        private const string _durableAddOnKind = "Durable";
        private const string _unmanagedConsumableAddOnKind = "UnmanagedConsumable";

        public string SubscriptionStoreId = "";
        public StoreProduct SubscriptionStoreProduct;
        public bool IsUnlockAllFeatures = false;
        public string SubscriptionStorePrice = "Loading";
        public DateTimeOffset ExpirationDate;

        public async Task<bool> CheckConnectionToMs()
        {
            StoreContext context = StoreContext.GetDefault();
            var filter = new string[] { _consumableAddOnKind, _durableAddOnKind, _unmanagedConsumableAddOnKind };
            StoreProductQueryResult result = await context.GetAssociatedStoreProductsAsync(filter);

            if(result.ExtendedError != null)
            {
                Debug.WriteLine(result.ExtendedError.Message);

                return false;
            }

            return true;
        }

        #region Xử lý subcription

        public async Task SetupSubscriptionInfoAsync()
        {
            if(Context == null)
            {
                //Reset context if set up again
                Context = StoreContext.GetDefault();
            }

            bool userOwnsSubscription = await CheckIfUserHasSubscriptionAsync();
            if (userOwnsSubscription)
            {
                // Unlock all the subscription add-on features here.
                IsUnlockAllFeatures = true;
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
                SubscriptionStorePrice = SubscriptionStoreProduct.Skus[1].Price.FormattedPrice;
            }
            else
            {
                // You can display the subscription purchase info to the customer here. You can use 
                // sku.SubscriptionInfo.BillingPeriod and sku.SubscriptionInfo.BillingPeriodUnit
                // to provide the renewal details.
                SubscriptionStorePrice = sku.Price.FormattedPrice;
            }

            // Prompt the customer to purchase the subscription.
        }
        public async Task RequestPurchaseSubscriptionAsync()
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
                    IsUnlockAllFeatures = true;
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

        private async Task<bool> CheckIfUserHasSubscriptionAsync()
        {
            StoreAppLicense appLicense = await Context.GetAppLicenseAsync();

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
                await Context.GetAssociatedStoreProductsAsync(new string[] { "Durable" });

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

        #endregion
    }
}
