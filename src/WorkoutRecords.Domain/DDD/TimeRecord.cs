using WorkoutRecords.Domain.Exceptions;

namespace WorkoutRecords.Domain;

public class TimeRecord : Record
{
    private TimeRecord(Guid workoutId, DateTimeOffset date, TimeSpan time)
        : base(workoutId, date)
    {
        Time = time;
    }

    public TimeSpan Time { get; }

    public static TimeRecord Create(Guid workoutId, DateTimeOffset date, TimeSpan time)
    {
        if (time <= TimeSpan.Zero)
        {
            throw new InvalidRecordException("Time must be greater than 0.");
        }

        return new TimeRecord(workoutId, date, time);
    }
}
