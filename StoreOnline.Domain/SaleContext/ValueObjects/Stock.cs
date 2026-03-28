using Flunt.Notifications;
using Flunt.Validations;
using StoreOnline.Domain.SharedContext.ValueObjects;

namespace StoreOnline.Domain.SaleContext.ValueObjects;

public sealed class Stock : ValueObject
{
    public Stock(int quantity)
    {
        var contract = new Contract<Notification>()
            .Requires()
            // Juntamos as regras aqui: o estoque deve ser válido desde o momento em que é instanciado.
            // Presumi que o estoque pode ser 0 (produto esgotado), então mantive o IsGreaterOrEqualsThan.
            .IsGreaterOrEqualsThan(quantity, 0, "Quantity", "A quantidade do estoque não pode ser menor que zero")
            .IsLowerOrEqualsThan(quantity, 1000, "Quantity", "A quantidade não pode exceder 1000 unidades");

        AddNotifications(contract);
        Quantity = quantity;
    }

    public int Quantity { get; private set; }
    
    // Converte de Stock para int: permite usar o objeto onde se espera um inteiro
    public static implicit operator int(Stock stock) => stock.Quantity;
    // Converte de int para Stock: permite criar o VO sem dar o "new" explicitamente
    public static implicit operator Stock(int quantity) => new Stock(quantity);
}