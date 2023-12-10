using WorkoutRecords.Domain.DDD.Exceptions;

namespace WorkoutRecords.Domain.DDD;

public class Reps
{
    private const int _min = 0;

    private readonly int _value;

    private Reps(int value) => _value = value;

    public static Reps Count(int value) =>
        value > _min
            ? new(value)
            : throw new InvalidRecordException("Reps count must be greater than 0.");

    public static implicit operator int(Reps repsCount) => repsCount._value;

    public static explicit operator Reps(int value) => Count(value);
}
