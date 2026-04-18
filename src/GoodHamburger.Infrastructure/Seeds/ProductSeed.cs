using GoodHamburger.Domain.Entities;
using GoodHamburger.Domain.Enum;

namespace GoodHamburger.Infrastructure.Persistence.Seeds;

public static class ProductSeed
{
    public static IEnumerable<Product> Data()
    {
        return
        [
            new Product
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "X Burger",
                Category = ProductCategory.Sandwich,
                Price = 5.00m
            },

            new Product
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "X Egg",
                Category = ProductCategory.Sandwich,
                Price = 4.50m
            },

            new Product
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "X Bacon",
                Category = ProductCategory.Sandwich,
                Price = 7.00m
            },

            new Product
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Batata frita",
                Category = ProductCategory.Fries,
                Price = 2.00m
            },

            new Product
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Name = "Refrigerante",
                Category = ProductCategory.Drink,
                Price = 2.50m
            }
        ];
    }
}