using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Distance : ValueObject
{
    private const int _min = 0;

    private readonly int _value;

    private Distance(int value) => _value = value;

    public static Distance InMeters(int value) =>
        value > _min
            ? new(value)
            : throw new InvalidRecordException("Distance must be greater than 0.");

    public static implicit operator int(Distance distance) => distance._value;

    public static explicit operator Distance(int value) => InMeters(value);

    public static bool operator ==(Distance left, Distance right) => EqualOperator(left, right);

    public static bool operator !=(Distance left, Distance right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => _value.ToString() + "m";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
