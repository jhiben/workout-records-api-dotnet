namespace WorkoutRecords.Domain.DDD;

public class DistanceWorkoutMovement : WorkoutMovement
{
    private DistanceWorkoutMovement(Movement movement, Distance distance)
        : base(movement)
    {
        Distance = distance;
    }

    public Distance Distance { get; }

    public static DistanceWorkoutMovement Define(Movement movement, int distance) =>
        new(movement, Distance.InMeters(distance));

    public override string ToString() => $"{Movement.Name} - {Distance}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Movement;
        yield return Distance;
    }
}
