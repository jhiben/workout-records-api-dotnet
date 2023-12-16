namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidWeightException : DomainException
{
    public InvalidWeightException(int weight)
        : base($"Invalid weight: {weight}") { }

    public InvalidWeightException(string message)
        : base(message) { }
}
