namespace WorkoutRecords.Domain.CRUD;

public class Workout
{
    public List<WorkoutMovement> Movements { get; set; } = new();

    public TimeSpan TimeCap { get; set; }

    public int RoundsCount { get; set; }
}
