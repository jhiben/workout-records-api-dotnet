using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Weight : ValueObject
{
    private const int _min = 0;

    private readonly int _value;

    private Weight(int value) => _value = value;

    public static Weight InKilograms(int value) =>
        value > _min
            ? new(value)
            : throw new InvalidRecordException("Weight must be greater than 0.");

    public static implicit operator int(Weight weight) => weight._value;

    public static explicit operator Weight(int value) => InKilograms(value);

    public static bool operator ==(Weight left, Weight right) => EqualOperator(left, right);

    public static bool operator !=(Weight left, Weight right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
