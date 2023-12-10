namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidTimeException : DomainException
{
    public InvalidTimeException(int time)
        : base($"Invalid time: {time}") { }

    public InvalidTimeException(string message)
        : base(message) { }
}
