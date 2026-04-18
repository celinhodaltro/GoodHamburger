namespace GoodHamburger.Domain.Entities;

public class OrderItem : Entity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}
