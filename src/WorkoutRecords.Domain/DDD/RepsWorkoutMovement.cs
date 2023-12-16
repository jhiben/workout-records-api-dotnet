namespace WorkoutRecords.Domain.DDD;

public class RepsWorkoutMovement : WorkoutMovement
{
    private RepsWorkoutMovement(Movement movement, Reps reps)
        : base(movement)
    {
        Reps = reps;
    }

    public Reps Reps { get; set; }

    public static RepsWorkoutMovement Define(Movement movement, int reps) =>
        new(movement, Reps.Count(reps));

    public override string ToString() => $"{Movement.Name} - {Reps} reps";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Movement;
        yield return Reps;
    }
}
