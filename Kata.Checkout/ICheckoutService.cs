namespace Kata.Checkout
{
    public interface ICheckoutService
    {
        void Scan(ShoppingItem item);

        decimal Checkout();
    }
}