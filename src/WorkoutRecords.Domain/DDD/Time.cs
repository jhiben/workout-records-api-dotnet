using WorkoutRecords.Domain.DDD.Exceptions;

namespace WorkoutRecords.Domain.DDD;

public class Time
{
    private readonly TimeSpan _value;

    private Time(TimeSpan time) => _value = time;

    public static Time Track(TimeSpan time) =>
        time > TimeSpan.Zero
            ? new(time)
            : throw new InvalidRecordException("Time must be greater than 0.");

    public static implicit operator TimeSpan(Time time) => time._value;

    public static explicit operator Time(TimeSpan time) => Track(time);
}
