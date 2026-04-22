using GoodHamburger.Domain.Entities;
using GoodHamburger.Shared.Enum;

namespace GoodHamburger.Domain.Rules
{
    public static class DiscountRule
    {
        public static void ApplyDiscountRule(this Order order)
        {
            order.Subtotal = order.OrderItems.Sum(x => x.Price);

            var categories = order.OrderItems
                .Select(x => x.Product.Category)
                .ToList();

            var hasSandwich = categories.Contains(ProductCategory.Sandwich);
            var hasFries = categories.Contains(ProductCategory.Fries);
            var hasDrink = categories.Contains(ProductCategory.Drink);

            order.Discount = 0;

            if (hasSandwich && hasFries && hasDrink)
                order.PercentDiscount  = 0.20m;
            else if (hasSandwich && hasDrink)
                order.PercentDiscount = 0.15m;
            else if (hasSandwich && hasFries)
                order.PercentDiscount = 0.10m;

            order.Discount = order.Subtotal * order.PercentDiscount;
            order.Total = order.Subtotal - order.Discount;

        }

    }
}
