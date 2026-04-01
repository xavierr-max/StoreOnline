using StoreOnline.Domain.SaleContext.ValueObjects;
using StoreOnline.Domain.SharedContext.AggregateRoots.Abstractions;
using StoreOnline.Domain.SharedContext.Entities;

namespace StoreOnline.Domain.SaleContext.Entities;

public class Product : Entity, IAggregateRoot
{
    public Product(
        string name,
        Price price,
        Stock stock,
        string? description = null)
    {
        Name = name;
        Price = price;
        Stock = stock;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Description = description;
    }

    // EF Core constructor
    protected Product() { }

    public string Name { get; private set; }
    public Price Price { get; private set; }
    public string? Description { get; private set; }
    public Stock Stock { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void UpdatePrice(decimal price)
    {
        // O operador implícito cria um 'new Price(price)', validando a regra.
        var newPrice = (Price)price;

        // Opcional, mas recomendado: trazer as notificações do VO para a Entidade
        AddNotifications(newPrice);

        if (newPrice.IsValid)
        {
            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void UpdateStock(int quantity)
    {
        var newStock = (Stock)quantity;

        AddNotifications(newStock);

        if (newStock.IsValid)
        {
            Stock = newStock;
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateDescription(string description) => Description = description;
}