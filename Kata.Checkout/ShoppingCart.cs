namespace Kata.Checkout
{
    using System.Collections.Generic;

    public class ShoppingCart : IShoppingCart
    {
        private readonly IPromotionService _promotionService;
        private readonly IDictionary<ShoppingItem, int> _items = new Dictionary<ShoppingItem, int>();

        public ShoppingCart(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public void AddToBucket(ShoppingItem item)
        {
            if (_items.TryGetValue(item, out var count))
            {
                _items[item]++;
            }
            else
            {
                _items[item] = 1;
            }
        }

        public decimal Checkout()
        {
            decimal totalPrice = 0m;

            foreach (var item in _items.Keys)
            {
                totalPrice += _promotionService.Apply(item, _items[item]);
            }

            return totalPrice;
        }
    }
}