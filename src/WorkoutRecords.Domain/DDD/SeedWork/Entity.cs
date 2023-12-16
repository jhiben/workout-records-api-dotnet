namespace WorkoutRecords.Domain.DDD.SeedWork;

public abstract class Entity<T>
    where T : struct, IEquatable<T>, IComparable<T>
{
    int? _requestedHashCode;

    public T Id { get; }

    protected Entity(T id) => Id = id;

    // private List<INotification> _domainEvents;
    // public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

    // public void AddDomainEvent(INotification eventItem)
    // {
    //     _domainEvents = _domainEvents ?? new List<INotification>();
    //     _domainEvents.Add(eventItem);
    // }

    // public void RemoveDomainEvent(INotification eventItem)
    // {
    //     _domainEvents?.Remove(eventItem);
    // }

    // public void ClearDomainEvents()
    // {
    //     _domainEvents?.Clear();
    // }

    public override bool Equals(object? obj)
    {
        if (obj is null or not Entity<T>)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        var item = (Entity<T>)obj;

        return item.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        _requestedHashCode ??= Id.GetHashCode() ^ 31;

        return _requestedHashCode.Value;
    }

    public static bool operator ==(Entity<T> left, Entity<T> right) =>
        Equals(left, null) ? Equals(right, null) : left.Equals(right);

    public static bool operator !=(Entity<T> left, Entity<T> right) => !(left == right);
}
