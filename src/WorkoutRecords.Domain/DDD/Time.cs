using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Time : ValueObject
{
    private readonly TimeSpan _value;

    private Time(TimeSpan time) => _value = time;

    public static Time Track(TimeSpan time) =>
        time > TimeSpan.Zero
            ? new(time)
            : throw new InvalidRecordException("Time must be greater than 0.");

    public static implicit operator TimeSpan(Time time) => time._value;

    public static explicit operator Time(TimeSpan time) => Track(time);

    public static bool operator ==(Time left, Time right) => EqualOperator(left, right);

    public static bool operator !=(Time left, Time right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
