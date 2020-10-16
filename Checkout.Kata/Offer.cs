namespace Checkout.Kata
{
    public class Offer : Item
    {
        public int Quantity { get; }

        public Offer(string sku, decimal unitPrice, int quantity) : base(sku, unitPrice)
        {
            Quantity = quantity;
        }
    }
}