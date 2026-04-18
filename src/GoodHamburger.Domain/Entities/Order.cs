namespace GoodHamburger.Domain.Entities;
public class Order : Entity
{
    public IEnumerable<OrderItem> OrderItems { get; set; } = [];
}
