namespace Kata.Checkout
{
    public interface IPromotionService
    {
        decimal Apply(ShoppingItem item, int groupSize);
    }
}