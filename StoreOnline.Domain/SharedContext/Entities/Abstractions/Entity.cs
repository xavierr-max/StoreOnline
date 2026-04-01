using Flunt.Notifications;

namespace StoreOnline.Domain.SharedContext.Entities;

public abstract class Entity : Notifiable<Notification>, IEquatable<Guid>
{
    protected Entity()
        => Id = Guid.CreateVersion7();

    public Guid Id { get; init; }

    public bool Equals(Guid id)
        => Id == id;

    public override int GetHashCode()
        => Id.GetHashCode();
}