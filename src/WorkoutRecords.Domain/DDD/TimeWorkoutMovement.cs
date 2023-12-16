namespace WorkoutRecords.Domain.DDD;

public class TimeWorkoutMovement : WorkoutMovement
{
    private TimeWorkoutMovement(Movement movement, Time time)
        : base(movement)
    {
        Time = time;
    }

    public Time Time { get; set; }

    public static TimeWorkoutMovement Define(Movement movement, TimeSpan time) =>
        new(movement, Time.Track(time));

    public override string ToString() => $"{Movement.Name} - {Time}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Movement;
        yield return Time;
    }
}
