namespace Kata.Checkout
{
    using System;

    public class ShoppingItem : IEquatable<ShoppingItem>
    {
        public string ProductCode { get; }

        public decimal UnitPrice { get; }

        public PromotionDefinition Promotion { get; }

        public ShoppingItem(string productCode, decimal unitPrice, PromotionDefinition promotion = null)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                throw new ArgumentNullException(nameof(productCode));
            }

            ProductCode = productCode;
            UnitPrice = unitPrice;
            Promotion = promotion;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals(obj as ShoppingItem);
        }

        public bool Equals(ShoppingItem other)
        {
            if (other == null)
                return false;

            return ProductCode == other.ProductCode;
        }

        public override int GetHashCode() =>
            (ProductCode != null ? ProductCode.GetHashCode() : 0);
    }
}