using StoreOnline.Domain.SharedContext.Entities;

namespace StoreOnline.Domain.SaleContext.Entities;

public class OrderItem : Entity
{
    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public int Quantity { get; set; }
    public Product Product { get; set; }
    public decimal SubTotal => Quantity * Product.Price;
}