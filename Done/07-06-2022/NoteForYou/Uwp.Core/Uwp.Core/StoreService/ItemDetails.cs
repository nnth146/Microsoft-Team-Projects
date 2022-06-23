using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Core.StoreService
{
    public class ItemDetails
    {
        public string Title { get; private set; }
        public string Price { get; private set; }
        public bool InCollection { get; private set; }
        public string ProductKind { get; private set; }
        public string StoreId { get; private set; }
        public string Description { get; private set; }
        public string FormattedTitle => $"{Title} ({ProductKind}) {Price}, InUserCollection:{InCollection}";
        public int Quantity { get; private set; }

        public ItemDetails(Windows.Services.Store.StoreProduct product)
        {
            Title = product.Title;
            Price = product.Price.FormattedPrice;
            InCollection = product.IsInUserCollection;
            ProductKind = product.ProductKind;
            StoreId = product.StoreId;
            Description = product.Description;
            Quantity = _items[StoreId];
        }

        private static Dictionary<string, int> _items = _getItems();

        private static Dictionary<string, int> _getItems()
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            items.Add("9NBT5MWS8359", 20);
            items.Add("9PNBHL570VRN", 40);
            items.Add("9NGLHLPJ2HZV", 60);
            items.Add("9PJV60FFVVBP", 110);
            items.Add("9N7L1D5ZWX8C", 230);
            items.Add("9P71D5GBS01B", 0);
            return items;
        }
    };
}
