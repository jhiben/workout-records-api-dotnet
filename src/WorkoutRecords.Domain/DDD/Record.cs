namespace WorkoutRecords.Domain.DDD;

public abstract class Record(DateOnly date)
{
    public DateOnly Date { get; } = date;

    public static RecordBuilder Create(DateOnly date) => new(date);
}
