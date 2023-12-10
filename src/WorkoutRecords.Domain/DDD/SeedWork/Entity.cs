namespace WorkoutRecords.Domain.DDD.SeedWork;

public abstract class Entity
{
    int? _requestedHashCode;

    int _id;

    public virtual int Id
    {
        get => _id;
        protected set { _id = value; }
    }

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

    public bool IsTransient() => Id == default;

    public override bool Equals(object? obj)
    {
        if (obj is null or not Entity)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        var item = (Entity)obj;

        return !item.IsTransient() && !IsTransient() && item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            _requestedHashCode ??= Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }

        return base.GetHashCode();
    }

    public static bool operator ==(Entity left, Entity right) =>
        Equals(left, null) ? Equals(right, null) : left.Equals(right);

    public static bool operator !=(Entity left, Entity right) => !(left == right);
}
