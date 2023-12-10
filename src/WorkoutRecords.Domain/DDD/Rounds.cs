using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Rounds : ValueObject
{
    private const int _min = 0;

    private readonly int _value;

    private Rounds(int value) => _value = value;

    public static readonly Rounds AMRAP = new(int.MaxValue);

    public static Rounds Count(int value) =>
        value > _min
            ? new(value)
            : throw new InvalidRoundsException("Rounds count must be greater than 0.");

    public static implicit operator int(Rounds rounds) => rounds._value;

    public static explicit operator Rounds(int value) => Count(value);

    public static bool operator ==(Rounds left, Rounds right) => EqualOperator(left, right);

    public static bool operator !=(Rounds left, Rounds right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => _value.ToString();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
