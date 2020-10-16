using System;
using System.Collections.Generic;

namespace Checkout.Kata
{
    public class Checkout
    {
        public decimal Total()
        {
            return _runningTotal;
        }
 
        public List<Item> Basket => _basket;
        private readonly List<Item> _basket = new List<Item>();

        private decimal _runningTotal = 0m;
        
        public void Scan(Item item)
        {
            _runningTotal += item.UnitPrice;
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