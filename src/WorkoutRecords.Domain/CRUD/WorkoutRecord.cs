namespace WorkoutRecords.Domain.CRUD;

public class WorkoutRecord
{
    public Workout Workout { get; set; } = new();

    public TimeSpan Time { get; set; }

    public int RepsCount { get; set; }
}
