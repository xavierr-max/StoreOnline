using Flunt.Notifications;
using Flunt.Validations;
using StoreOnline.Application.SharedContext.UseCases;
using StoreOnline.Domain.SaleContext.Entities;
using StoreOnline.Domain.SaleContext.Repositories;

namespace StoreOnline.Application.SaleContext.UseCases.Create;

public class Handler : IHandler<Request, Response>
{
    private readonly IProductRepository _productRepository;

    public Handler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

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
            // 2. RECUPERAR DADOS DAS ENTITIES PELOS REPOS (se necessário)
            // Neste caso, não há necessidade de recuperar dados externos,
            // mas você poderia adicionar verificações como:
            // - Verificar se o produto já existe
            // - Recuperar dados de referência

            // 3. CRIAR NOVO OBJETO DA ENTITY
            // Cria a instância de Product passando os dados do Command
            var product = new Product(
                request.Name,
                request.Price,
                request.Stock,
                request.Description
            );

            // 4. CHAMAR VALIDAÇÕES DA ENTITY
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

            // 5. SALVAR NO BANCO O NOVO OBJETO
            await _productRepository.CreateAsync(product, CancellationToken.None);

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