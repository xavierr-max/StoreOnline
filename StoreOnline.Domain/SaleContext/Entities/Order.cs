using StoreOnline.Domain.SharedContext.Entities;

namespace StoreOnline.Domain.SaleContext.Entities;

public class Order : Entity
{
    public Order()
    {
        Id = Guid.NewGuid();
    }

    public OrderItem Item { get; set; }
    public decimal Discount { get; set; }
    public bool Status { get; set; }
    public decimal Total { get; set; }
}