namespace Kata.Checkout.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CheckoutServiceTests
    {
        private Mock<IShoppingCart> _shoppingCartMock;
        private CheckoutService _sut;

        [SetUp]
        public void Setup()
        {
            _shoppingCartMock = new Mock<IShoppingCart>();
        }

        [Test]
        public void ShouldScanThrowExceptionWhenItemIsNull()
        {
            _sut = new CheckoutService(_shoppingCartMock.Object);

            Assert.Throws<ArgumentNullException>(() => _sut.Scan(null));

            _shoppingCartMock.Verify(s => s.AddToBucket(It.IsAny<ShoppingItem>()), Times.Never);
        }

        [Test]
        public void ShouldScanAddItemInCart()
        {
            _sut = new CheckoutService(_shoppingCartMock.Object);

            var item = new ShoppingItem("Bananas", 0.7m, new PromotionDefinition(2, 1m));
            _sut.Scan(item);

            _shoppingCartMock.Verify(s => s.AddToBucket(item), Times.Once);
        }

        [Test]
        public void ShouldCheckoutCalculatePrice()
        {
            _shoppingCartMock.Setup(s => s.Checkout()).Returns(10m);
            _sut = new CheckoutService(_shoppingCartMock.Object);

            var total = _sut.Checkout();

            Assert.AreEqual(10, total);
            _shoppingCartMock.Verify(s => s.Checkout(), Times.Once);
        }
    }
}