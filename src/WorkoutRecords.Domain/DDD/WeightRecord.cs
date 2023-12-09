using WorkoutRecords.Domain.Exceptions;

namespace WorkoutRecords.Domain;

public class WeightRecord : Record
{
    private WeightRecord(Guid workoutId, DateTimeOffset date, int weight)
        : base(workoutId, date)
    {
        Weight = weight;
    }

    public int Weight { get; }

    public static WeightRecord Create(Guid workoutId, DateTimeOffset date, int weight)
    {
        if (weight <= 0)
        {
            throw new InvalidRecordException("Weight must be greater than 0.");
        }

        return new WeightRecord(workoutId, date, weight);
    }
}
