using StoreOnline.Domain.SharedContext.Entities;

namespace StoreOnline.Domain.SaleContext.Entities;

public class Discount : Entity
{
    public Discount()
    {
    }

    //prop nome
    public string Number { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
    //prop value
}