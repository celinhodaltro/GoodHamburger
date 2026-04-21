using GoodHamburger.Domain.Entities;
using GoodHamburger.Shared.Enum;
using GoodHamburger.Infrastructure.Persistence;

namespace GoodHamburger.Infrastructure.Seeds;

public sealed class ProductSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        if (context.Products.Any())
            return;

        await context.Products.AddRangeAsync(Data(), cancellationToken);
    }

    private IEnumerable<Product> Data()
    {
        return
        [
            new Product
        {
            Id = Guid.NewGuid(),
            Name = "X Burger",
            Category = ProductCategory.Sandwich,
            Price = 5.00m,
            Description = "Hambúrguer artesanal com queijo e molho especial"
        },

        new Product
        {
            Id = Guid.NewGuid(),
            Name = "X Egg",
            Category = ProductCategory.Sandwich,
            Price = 4.50m,
            Description = "Hambúrguer com ovo, queijo e maionese da casa"
        },

        new Product
        {
            Id = Guid.NewGuid(),
            Name = "X Bacon",
            Category = ProductCategory.Sandwich,
            Price = 7.00m,
            Description = "Hambúrguer com bacon crocante e cheddar derretido"
        },

        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Batata frita",
            Category = ProductCategory.Fries,
            Price = 2.00m,
            Description = "Batatas douradas e crocantes"
        },

        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Refrigerante",
            Category = ProductCategory.Drink,
            Price = 2.50m,
            Description = "Lata 350ml gelada"
        }
        ];
    }
}