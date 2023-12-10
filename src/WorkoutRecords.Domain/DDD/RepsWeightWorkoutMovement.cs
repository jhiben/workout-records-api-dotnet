namespace WorkoutRecords.Domain.DDD;

public class RepsWeightWorkoutMovement : WorkoutMovement
{
    private RepsWeightWorkoutMovement(Movement movement, Reps reps, Weight weight)
        : base(movement)
    {
        Reps = reps;
        Weight = weight;
    }

    public Reps Reps { get; }

    public Weight Weight { get; }

    public static RepsWeightWorkoutMovement Create(Movement movement, int reps, int weight) =>
        new(movement, Reps.Count(reps), Weight.InKilograms(weight));

    public override string ToString() => $"{Movement.Name} - {Reps} reps at {Weight}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Movement;
        yield return Reps;
        yield return Weight;
    }
}
