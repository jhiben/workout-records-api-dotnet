namespace WorkoutRecords.Domain.DDD;

public class RepsRecord : Record
{
    private RepsRecord(DateOnly date, Reps reps)
        : base(date)
    {
        Reps = reps;
    }

    public Reps Reps { get; }

    public static RepsRecord Set(DateOnly date, int reps) => new(date, Reps.Count(reps));
}
