using Flunt.Notifications;
using StoreOnline.Application.SharedContext.UseCases;

namespace StoreOnline.Application.SaleContext.UseCases.Create;

public class Response : IResponse
{
    public string Message { get; set; } = string.Empty;
    public int Status { get; set; } = 400;
    public bool IsSucess => Status is >= 200 and <= 299;
    public IEnumerable<Notification>? Notifications { get; set; }
}