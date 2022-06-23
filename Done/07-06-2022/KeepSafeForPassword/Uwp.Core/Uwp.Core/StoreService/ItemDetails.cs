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
            items.Add("9PKCHZ5Q1JXT", 20);
            items.Add("9NWPTPK6R5J1", 40);
            items.Add("9NTP9R90VQLV", 60);
            items.Add("9PJZ2H8ZSSVR", 110);
            items.Add("9PBXWBQKP1BQ", 230);
            items.Add("9P683PCXN06B", 0);
            return items;
        }
    };
}
