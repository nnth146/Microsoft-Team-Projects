﻿using System;
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
            items.Add("9P9L2DW7W707", 20);
            items.Add("9PM46KVBKPN6", 40);
            items.Add("9P8HD3S9NKVW", 60);
            items.Add("9N17VFB3G92R", 110);
            items.Add("9PJD68HCB883", 230);
            items.Add("9NHC9BNQFV0C", 0);
            return items;
        }
    }
}
