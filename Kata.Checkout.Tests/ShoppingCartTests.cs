using NUnit.Framework;

namespace Kata.Checkout.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;

    [TestFixture]
    public class ShoppingCartTests
    {
        private Mock<IPromotionService> _promotionServiceMock;
        private ShoppingCart _sut;

        [SetUp]
        public void Setup()
        {
            _promotionServiceMock = new Mock<IPromotionService>();
        }

        [Test]
        public void ShouldAddToBucketAddsItems()
        {
            _sut = new ShoppingCart(_promotionServiceMock.Object);

            foreach (var item in Items)
            {
                _sut.AddToBucket(item);
            }

            Assert.IsTrue(_sut.Items.Any(i => i.Key.ProductCode == "Apples" && i.Value == 1));
            Assert.IsTrue(_sut.Items.Any(i => i.Key.ProductCode == "Bananas" && i.Value == 2));
            Assert.IsTrue(_sut.Items.Any(i => i.Key.ProductCode == "Oranges" && i.Value == 3));
        }

        [Test]
        public void ShouldCheckoutReturnCorrectTotalPrice()
        {
            _promotionServiceMock.Setup(p => p.Apply(It.IsAny<ShoppingItem>(), It.IsAny<int>())).Returns(10);
            _sut = new ShoppingCart(_promotionServiceMock.Object);

            foreach (var item in Items)
            {
                _sut.AddToBucket(item);
            }

            var total = _sut.Checkout();

            Assert.AreEqual(30, total);
            _promotionServiceMock.Verify(p => p.Apply(It.IsAny<ShoppingItem>(), It.IsAny<int>()), Times.Exactly(3));
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