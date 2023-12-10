using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Reps : ValueObject
{
    private const int _min = 0;

    private readonly int _value;

    private Reps(int value) => _value = value;

    public static Reps Count(int value) =>
        value > _min
            ? new(value)
            : throw new InvalidRepsException("Reps count must be greater than 0.");

    public static implicit operator int(Reps reps) => reps._value;

    public static explicit operator Reps(int value) => Count(value);

    public static bool operator ==(Reps left, Reps right) => EqualOperator(left, right);

    public static bool operator !=(Reps left, Reps right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => _value.ToString();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
