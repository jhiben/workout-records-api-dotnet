using WorkoutRecords.Domain.Exceptions;

namespace WorkoutRecords.Domain;

public class RepsRecord : Record
{
    private RepsRecord(Guid workoutId, DateTimeOffset date, int reps)
        : base(workoutId, date)
    {
        Reps = reps;
    }

    public int Reps { get; }

    public static RepsRecord Create(Guid workoutId, DateTimeOffset date, int reps)
    {
        if (reps <= 0)
        {
            throw new InvalidRecordException("Reps must be greater than 0.");
        }

        return new RepsRecord(workoutId, date, reps);
    }
}
