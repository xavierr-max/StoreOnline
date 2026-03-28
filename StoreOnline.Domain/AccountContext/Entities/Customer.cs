using StoreOnline.Domain.AccountContext.ValueObjects;
using StoreOnline.Domain.SharedContext.Entities;

namespace StoreOnline.Domain.AccountContext.Entities;

public class Customer : Entity
{
    public Customer(
        Name name,
        string email,
        string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public Name Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}