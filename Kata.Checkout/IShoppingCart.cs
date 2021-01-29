namespace Kata.Checkout
{
    using System.Collections.Generic;

    public interface IShoppingCart
    {
        void AddToBucket(ShoppingItem item);

        decimal Checkout();
    }
}