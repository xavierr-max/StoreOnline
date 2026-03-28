using StoreOnline.Application.SaleContext.UseCases.Create;

namespace StoreOnline.Application.SharedContext.UseCases;

public interface IRequest<T> where T : IResponse;