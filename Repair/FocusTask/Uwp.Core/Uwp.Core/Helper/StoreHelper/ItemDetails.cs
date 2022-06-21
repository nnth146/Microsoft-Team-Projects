using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Core.Helper
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
            items.Add("9N7TXDR9N0W9", 20);
            items.Add("9PH3RS977J0X", 40);
            items.Add("9N2JRL81CLVN", 60);
            items.Add("9NL41Q3X5VNJ", 110);
            items.Add("9PB3TCGSHCSQ", 230);
            items.Add("9NGLN5CJ36LH", 0);
            return items;
        }
    };
}
