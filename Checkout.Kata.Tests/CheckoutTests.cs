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

            Assert.DoesNotThrow( () => checkout.Scan(new Item()));
        }
    }
}