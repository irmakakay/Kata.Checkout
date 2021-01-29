namespace Kata.Checkout
{
    public class PromotionDefinition
	{
		public int SameItemCount { get; }

		public decimal DiscountedPrice { get; }

        public PromotionDefinition(int sameItemCount, decimal discountedPrice)
        {
            SameItemCount = sameItemCount;
            DiscountedPrice = discountedPrice;
        }
	}
}
