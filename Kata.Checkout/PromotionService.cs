namespace Kata.Checkout
{
    public class PromotionService : IPromotionService
    {
        public decimal Apply(ShoppingItem item, int groupSize)
        {
            if (groupSize == 1)
            {
                return item.UnitPrice;
            }

            var applyCount = groupSize / item.Promotion.SameItemCount;
            var remainingCount = groupSize % item.Promotion.SameItemCount;

            return applyCount * item.Promotion.DiscountedPrice +
                   remainingCount * item.UnitPrice;
        }
    }
}