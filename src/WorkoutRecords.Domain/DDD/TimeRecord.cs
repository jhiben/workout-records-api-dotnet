namespace WorkoutRecords.Domain.DDD;

public class TimeRecord : Record
{
    private TimeRecord(DateOnly date, Time time)
        : base(date)
    {
        Time = time;
    }

    public Time Time { get; }

    public static TimeRecord Set(DateOnly date, TimeSpan time) => new(date, Time.Track(time));
}
