using System.Collections.Generic;

namespace Checkout.Kata
{
    public interface IProductRepository
    {
        public IEnumerable<Item> GetAllItems();
        public IEnumerable<Offer> GetAllOffers();
    }
}