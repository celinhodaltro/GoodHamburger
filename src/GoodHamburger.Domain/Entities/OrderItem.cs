namespace GoodHamburger.Domain.Entities;

public class OrderItem : Entity
{
    public OrderItem()
    {
    }

    public OrderItem(Product? product)
    {
        Product = product;
        Price = product?.Price ?? 0m;
        ProductId = product?.Id;
    }

    public decimal Price { get; set; }
    public Guid? OrderId { get; set; }
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
}
