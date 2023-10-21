namespace WorkoutRecords.Domain.CRUD;

public class Record
{
    public Workout Workout { get; set; } = new();

    public TimeSpan Time { get; set; }

    public int RepsCount { get; set; }
}