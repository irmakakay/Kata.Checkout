namespace Kata.Checkout.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PromotionServiceTests
    {
        private PromotionService _sut = new PromotionService();

        [Test]
        public void ShouldApplyReturnCalculatedPrice()
        {
            var item = new ShoppingItem("Bananas", 0.7m, new PromotionDefinition(2, 1m));

            var price = _sut.Apply(item, 5);

            Assert.AreEqual(2.7m, price);
        }

        [Test]
        public void ShouldApplyReturnUnitPrice()
        {
            var item = new ShoppingItem("Bananas", 0.7m, new PromotionDefinition(2, 1m));

            var price = _sut.Apply(item, 1);

            Assert.AreEqual(0.7m, price);
        }
    }
}