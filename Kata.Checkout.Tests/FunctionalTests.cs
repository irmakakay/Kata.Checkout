namespace Kata.Checkout.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class FunctionalTests
    {
        private ICheckoutService _checkoutService;
        private IPromotionService _promotionService;
        private IShoppingCart _shoppingCart;

        [SetUp]
        public void SetUp()
        {
            _promotionService = new PromotionService();
            _shoppingCart = new ShoppingCart(_promotionService);
            _checkoutService = new CheckoutService(_shoppingCart);
        }

        [Test]
        public void RunScenario()
        {
            foreach (var item in Items)
            {
                _checkoutService.Scan(item);
            }

            var total = _checkoutService.Checkout();
            Assert.AreEqual(2.4m, total);
        }

        private IEnumerable<ShoppingItem> Items
        {
            get
            {
                yield return new ShoppingItem("Apples", 0.5m);
                yield return new ShoppingItem("Bananas", 0.7m, new PromotionDefinition(2, 1m));
                yield return new ShoppingItem("Bananas", 0.7m, new PromotionDefinition(2, 1m));
                yield return new ShoppingItem("Oranges", 0.45m, new PromotionDefinition(3, 0.9m));
                yield return new ShoppingItem("Oranges", 0.45m, new PromotionDefinition(3, 0.9m));
                yield return new ShoppingItem("Oranges", 0.45m, new PromotionDefinition(3, 0.9m));
            }
        }
    }
}
