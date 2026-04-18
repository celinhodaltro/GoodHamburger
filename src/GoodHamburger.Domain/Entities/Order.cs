using GoodHamburger.Domain.Exceptions;

namespace GoodHamburger.Domain.Entities;
public class Order : Entity
{
    private readonly List<OrderItem> _orderItems = [];

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal PercentDiscount { get; set; }
    public decimal Total { get; set; }

    public OrderItem AddItem(OrderItem orderItem)
    {
        if (_orderItems.Any(x => x.Product!.Category == orderItem!.Product.Category))
            throw new BusinessException("Já existe item dessa categoria.");

        orderItem.OrderId = Id;
        _orderItems.Add(orderItem);

        return orderItem;
    }
}
