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
            items.Add("9MX18SG4XB6Z", 20);
            items.Add("9NL71L1G81XX", 40);
            items.Add("9PJ3XW51GPGD", 60);
            items.Add("9NST95HKQVZ9", 110);
            items.Add("9NTV66L8Q7W1", 230);
            items.Add("9N4J89PFMFW7", 0);
            return items;
        }
    };
}
