using GoodHamburger.Domain.Enum;

namespace GoodHamburger.Domain.Entities;

public class DiscountRule : Entity
{
    public string? Description { get; set; }
    public decimal Percent { get; set; }

    public IEnumerable<ProductCategory> Categories { get; set; } = [];
}
