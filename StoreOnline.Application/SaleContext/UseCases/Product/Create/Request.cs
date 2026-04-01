using StoreOnline.Application.SharedContext.UseCases;

namespace StoreOnline.Application.SaleContext.UseCases.Product.Create;

public class Request : IRequest<Response>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = string.Empty;
}