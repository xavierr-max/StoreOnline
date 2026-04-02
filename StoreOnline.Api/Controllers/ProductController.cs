using Microsoft.AspNetCore.Mvc;
using StoreOnline.Application.SaleContext.UseCases.Product.Create;
using StoreOnline.Application.SharedContext.UseCases;

namespace StoreOnline.Api.Controllers;

[ApiController]
[Route("v1/products")]
public class ProductController(IHandler<Request, Response> sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] Request command)
    {
        var result = await sender.Handle(command);
        return Created("", result);
    }
}