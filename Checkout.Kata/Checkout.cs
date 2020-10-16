using System;
using System.Collections.Generic;

namespace Checkout.Kata
{
    public class Checkout
    {
        public decimal Total()
        {
            return 0m;
        }
 
        public List<Item> Basket => _basket;
        private readonly List<Item> _basket = new List<Item>();
        
        public void Scan(Item item)
        {
            _basket.Add(item);
        }
    }

    public class Item
    {
        public string SKU { get; }
        public decimal UnitPrice { get; }

        public Item(string sku, decimal unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}