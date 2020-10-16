using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Kata
{
    public class Checkout
    {
        private readonly IProductRepository _productRepository;
        
        public Checkout(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public decimal Total()
        {
            return _basket.Sum(item => item.UnitPrice);
        }
 
        public List<Item> Basket => _basket;
        private readonly List<Item> _basket = new List<Item>();

        public void Scan(Item item)
        {
            _basket.Add(item);

            var matchingItems = _basket.Where(matchingItem => matchingItem.SKU == item.SKU).ToList();
            var availableOffer = _productRepository.GetAllOffers().FirstOrDefault(offer => offer.SKU == item.SKU);
            
            if (availableOffer == null || availableOffer.Quantity != matchingItems.Count) return;
            
            _basket.Add(availableOffer);

            matchingItems.ForEach(matchingItem => matchingItem.UnitPrice = 0m);
        }
    }

    public interface IProductRepository
    {
        public IEnumerable<Item> GetAllItems();
        public IEnumerable<Offer> GetAllOffers();
    }

    public class Offer : Item
    {
        public int Quantity { get; }

        public Offer(string sku, decimal unitPrice, int quantity) : base(sku, unitPrice)
        {
            Quantity = quantity;
        }
    }

    public class Item
    {
        public string SKU { get; }
        public decimal UnitPrice { get; set; }

        public Item(string sku, decimal unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}