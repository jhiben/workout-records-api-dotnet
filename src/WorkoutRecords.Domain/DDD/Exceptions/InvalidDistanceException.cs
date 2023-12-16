namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidDistanceException : DomainException
{
    public InvalidDistanceException(int distance)
        : base($"Invalid distance: {distance}") { }

    public InvalidDistanceException(string message)
        : base(message) { }
}
