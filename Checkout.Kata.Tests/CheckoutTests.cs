using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Checkout.Kata.Tests
{
    public class CheckoutTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockProductRepository = new Mock<IProductRepository>();

            _mockProductRepository.Setup(repository => repository.GetAllItems()).Returns(new List<Item>
            {
                new Item("A99", 0.5m),
                new Item("B15", 0.3m),
                new Item("C40", 0.6m)
            });

            _mockProductRepository.Setup(repository => repository.GetAllOffers()).Returns(new List<Offer>
            {
                new Offer("A99", 1.30m, 3),
                new Offer("B15", 0.45m, 2)
            });
        }

        public static IEnumerable<TestCaseData> CheckoutItemsWithTotalTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Item>
                {
                    new Item("A99", 0.50m),
                    new Item("A99", 0.50m),
                    new Item("A99", 0.50m)
                }, 1.30m).SetName("Three items with A99 product");
                yield return new TestCaseData(new List<Item>
                {
                    new Item("A99", 0.50m),
                    new Item("A99", 0.50m),
                    new Item("A99", 0.50m),
                    new Item("B15", 0.30m)
                }, 1.60m).SetName("Three items with A99 and one B15");
                yield return new TestCaseData(new List<Item>
                {
                    new Item("A99", 0.50m),
                    new Item("B15", 0.30m),
                    new Item("A99", 0.50m),
                    new Item("B15", 0.30m),
                    new Item("A99", 0.50m)
                }, 1.75m).SetName("Mix of items with expected discount");
                yield return new TestCaseData(new List<Item>
                {
                    new Item("A99", 0.50m),
                    new Item("B15", 0.30m),
                    new Item("C40", 0.60m)
                }, 1.40m).SetName("Mix of items with total");
            }
        }
        
        [Test]
        public void ScanItem()
        {
            var checkout = new Checkout(_mockProductRepository.Object);
            
            // Create out first item and try to scan it
            var item = new Item("A99", 0.50m);
            
            // Verify we can scan
            Assert.DoesNotThrow( () => checkout.Scan(item));
            
            // Verify that we've stored that scanned item
            Assert.That(checkout.Basket.Contains(item));
        }

        [Test]
        public void ScanItemGetTotal()
        {
            decimal expectedTotal = 0.50m;
            var checkout = new Checkout(_mockProductRepository.Object);
            var item = new Item("A99", 0.50m);

            checkout.Scan(item);
            
            Assert.AreEqual(expectedTotal, checkout.Total());
        }

        [Test]
        public void AddItemsWithOffer()
        {
            var checkout = new Checkout(_mockProductRepository.Object);
            var items = new List<Item> {new Item("A99", 0.50m), new Item("A99", 0.50m), new Item("A99", 0.50m)};
            var expectedTotal = 1.30m;
            
            items.ForEach(item => checkout.Scan(item));
            
            Assert.AreEqual(expectedTotal, checkout.Total());
        }

        [Test]
        [TestCaseSource(nameof(CheckoutItemsWithTotalTestCases))]
        public void AddMultipleItemsWithOffers(List<Item> items, decimal expectedTotal)
        {
            var checkout = new Checkout(_mockProductRepository.Object);
            
            items.ForEach(item => checkout.Scan(item));
            
            Assert.AreEqual(expectedTotal, checkout.Total());
        }
    }
}