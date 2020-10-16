using NUnit.Framework;

namespace Checkout.Kata.Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScanItem()
        {
            var checkout = new Checkout();
            
            // Create out first item and try to scan it
            var item = new Item("A99", 0.50m);
            
            Assert.DoesNotThrow( () => checkout.Scan(item));
        }
    }
}