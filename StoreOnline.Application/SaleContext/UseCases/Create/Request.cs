using StoreOnline.Application.SharedContext.UseCases;
using StoreOnline.Domain.SaleContext.ValueObjects;

namespace StoreOnline.Application.SaleContext.UseCases.Create;

public class Request : IRequest<Response>
{
    public Request(string name, decimal price, int stock, string description)
    {
        Name = name;
        Price = new Price(price);
        Stock = new Stock(stock);
        Description = description;
    }

    public Request(string name, decimal price, int stock)
    {
        Name = name;
        Price = new Price(price);
        Stock = new Stock(stock);
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = string.Empty;
}