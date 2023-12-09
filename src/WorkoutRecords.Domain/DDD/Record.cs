namespace WorkoutRecords.Domain;

public abstract class Record(Guid workoutId, DateTimeOffset date)
{
    public Guid WorkoutId { get; } = workoutId;

    public DateTimeOffset Date { get; } = date;

    public static RecordBuilder Create(Guid workoutId, DateTimeOffset date) => new(workoutId, date);
}
