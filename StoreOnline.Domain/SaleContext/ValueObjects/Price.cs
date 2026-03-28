using Flunt.Notifications;
using Flunt.Validations;
using StoreOnline.Domain.SharedContext.ValueObjects;

namespace StoreOnline.Domain.SaleContext.ValueObjects;

public sealed class Price : ValueObject
{
    public Price(decimal value)
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(value, 0, "Value", "O valor deve ser maior do que zero");

        AddNotifications(contract);
        Value = value;
    }

    public decimal Value { get; private set; }

    public static implicit operator decimal(Price price) => price.Value;
    public static implicit operator Price(decimal value) => new Price(value);
}