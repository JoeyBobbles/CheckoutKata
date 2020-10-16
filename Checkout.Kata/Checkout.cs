using System;

namespace Checkout.Kata
{
    public class Checkout
    {
        public decimal Total()
        {
            return 0m;
        }
 
        public void Scan(Item item)
        {
            
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