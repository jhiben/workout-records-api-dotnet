using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public abstract class Record(DateOnly date) : ValueObject
{
    public DateOnly Date { get; } = date;

    public static RecordBuilder Create(DateOnly date) => new(date);

    public static bool operator ==(Record left, Record right) => EqualOperator(left, right);

    public static bool operator !=(Record left, Record right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}
