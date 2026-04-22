using GoodHamburger.Domain.Exceptions;
using GoodHamburger.Domain.Rules;

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
        if (_orderItems.Any(x => x.Product!.Category == orderItem.Product!.Category))
            throw new BusinessException($"Não é permitido adicionar mais de um item da mesma categoria no pedido. Categoria duplicada: '{orderItem.Product!.Category}'.");

        orderItem.OrderId = Id;
        _orderItems.Add(orderItem);

        this.ApplyDiscountRule();

        return orderItem;
    }

    public bool ClearItems()
    {
        _orderItems.Clear();
        Subtotal = 0;
        Discount = 0;
        PercentDiscount = 0;
        Total = 0;

        return true;
    }
}
