using GoodHamburger.Domain.Enum;

namespace GoodHamburger.Domain.Entities;
public class Product : Entity
{
    public Product(){}

    public Product(string name, ProductCategory category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public string? Name { get; set; }
    public ProductCategory Category { get; set; }
    public decimal Price { get; set; }
}
