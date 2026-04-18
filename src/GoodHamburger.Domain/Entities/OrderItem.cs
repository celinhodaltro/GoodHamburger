namespace GoodHamburger.Domain.Entities;

public class OrderItem : Entity
{
    public decimal Price { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}
