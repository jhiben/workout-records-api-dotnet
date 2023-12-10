namespace WorkoutRecords.Domain.DDD;

public class DistanceWeightWorkoutMovement : WorkoutMovement
{
    private DistanceWeightWorkoutMovement(Movement movement, Distance distance, Weight weight)
        : base(movement)
    {
        Distance = distance;
        Weight = weight;
    }

    public Distance Distance { get; }

    public Weight Weight { get; }

    public static DistanceWeightWorkoutMovement Create(
        Movement movement,
        int distance,
        int weight
    ) => new(movement, Distance.InMeters(distance), Weight.InKilograms(weight));

    public override string ToString() => $"{Movement.Name} - {Distance} at {Weight}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Movement;
        yield return Distance;
        yield return Weight;
    }
}
