namespace Kata.Checkout.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ShoppingItemTests
    {
        [Test]
        public void ShouldEqualityCheckWorks()
        {
            var item1 = new ShoppingItem("Apples", 0.5m);
            var sameItem = new ShoppingItem("Apples", 0.5m);

            Assert.IsFalse(item1.Equals(null));
            Assert.IsTrue(item1.Equals((object)sameItem));
            Assert.IsFalse(item1.Equals("APPLES"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ShouldThrowExceptionWhenCodeIsNull(string code)
        {
            Assert.Throws<ArgumentNullException>(() => 
                _ = new ShoppingItem(code, It.IsAny<decimal>()));
        }

        [Test]
        public void ShouldGetHashCodeUseProductCodeOnly()
        {
            var item = new ShoppingItem("code", 1m);
            var item2 = new ShoppingItem("code", 2m);

            var code = item.GetHashCode();

            Assert.AreEqual(item.GetHashCode(), item2.GetHashCode());
        }
    }
}
