using Flunt.Notifications;
using Flunt.Validations;
using StoreOnline.Application.SharedContext.UseCases;
using StoreOnline.Domain.SaleContext.Repositories;
using StoreOnline.Domain.SharedContext.Repositories.Abstractions;

namespace StoreOnline.Application.SaleContext.UseCases.Product.Create;

public class Handler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IHandler<Request, Response>
{
    public async Task<Response> Handle(Request request)
    {
        // 1. FAIL FAST VALIDATION - Valida o request antes de processar
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(request, nameof(request), "Request não pode ser nulo")
            .IsNotNullOrEmpty(request.Name, nameof(request.Name), "Nome do produto é obrigatório")
            .IsGreaterThan(request.Price, 0, "Price", "O preço deve ser maior que zero")
            .IsGreaterOrEqualsThan(request.Stock, 0, "Stock", "O estoque não pode ser negativo");

        if (!contract.IsValid)
        {
            return new Response
            {
                Message = "Validação falhou",
                Status = 400,
                Notifications = contract.Notifications
            };
        }

        try
        {
            // 2. CRIAR NOVO OBJETO DA ENTITY
            // Cria a instância de Product passando os dados do Command
            var product = new Domain.SaleContext.Entities.Product(
                request.Name,
                request.Price,
                request.Stock,
                request.Description
            );

            // 3. CHAMAR VALIDAÇÕES DA ENTITY
            // Verifica se a Entity tem notificações (validações falharam)
            if (!product.IsValid)
            {
                return new Response
                {
                    Message = "Produto inválido",
                    Status = 400,
                    Notifications = product.Notifications
                };
            }

            // 4. SALVAR NO BANCO O NOVO OBJETO
            await productRepository.CreateAsync(product, CancellationToken.None);
            await unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Produto criado com sucesso",
                Status = 201,
                Notifications = null
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                Message = $"Erro ao criar produto: {ex.Message}",
                Status = 500,
                Notifications = new[] { new Notification("Error", ex.Message) }
            };
        }
    }
}