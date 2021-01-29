namespace Kata.Checkout
{
    using System;

    public class CheckoutService : ICheckoutService
    {
        private readonly IShoppingCart _shoppingCart;

        public CheckoutService(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public void Scan(ShoppingItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _shoppingCart.AddToBucket(item);
        }

        public decimal Checkout()
        {
            return _shoppingCart.Checkout();
        }
    }
}