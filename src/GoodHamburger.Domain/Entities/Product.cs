using GoodHamburger.Domain.Enum;

namespace GoodHamburger.Domain.Entities;
public class Product : Entity
{
    public required string Name { get; set; }
    public ProductCategory Category { get; set; }
    public decimal Price { get; set; }
}
