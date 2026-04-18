namespace GoodHamburger.Domain.Entities;
public class Order : Entity
{
    public IEnumerable<OrderItem> OrderItems { get; set; } = [];
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal PercentDiscount { get; set; }
    public decimal Total { get; set; }
}
