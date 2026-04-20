namespace GoodHamburger.Shared.DTOs;
public class  OrderDto()
{
    public Guid Id { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal PercentDiscount { get; set; }
    public decimal Total {  get; set; }
}
