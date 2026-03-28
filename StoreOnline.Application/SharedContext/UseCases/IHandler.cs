namespace StoreOnline.Application.SharedContext.UseCases;

public interface IHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResponse
{
    Task<TResponse> Handle(TRequest request);
}