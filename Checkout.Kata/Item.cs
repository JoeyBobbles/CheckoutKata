namespace Checkout.Kata
{
    public class Item
    {
        public string Sku { get; }
        public decimal UnitPrice { get; set; }

        public Item(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}