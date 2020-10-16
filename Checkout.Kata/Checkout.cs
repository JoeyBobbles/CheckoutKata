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

            var matchingItems = _basket.Where(matchingItem => matchingItem.Sku == item.Sku).ToList();
            var availableOffer = _productRepository.GetAllOffers().FirstOrDefault(offer => offer.Sku == item.Sku);
            
            if (availableOffer == null || availableOffer.Quantity != matchingItems.Count) return;
            
            _basket.Add(availableOffer);

            matchingItems.ForEach(matchingItem => matchingItem.UnitPrice = 0m);
        }
    }
}