using WorkoutRecords.Domain.DDD.Exceptions;

namespace WorkoutRecords.Domain.DDD;

public class Weight
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
}
