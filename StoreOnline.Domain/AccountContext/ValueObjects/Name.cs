using StoreOnline.Domain.SharedContext.ValueObjects;

namespace StoreOnline.Domain.AccountContext.ValueObjects;

public sealed class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static implicit operator string(Name name) => name.ToString();

    public override string ToString()
        => $"{FirstName} {LastName}";
}