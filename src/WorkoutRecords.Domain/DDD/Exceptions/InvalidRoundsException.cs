namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidRoundsException : DomainException
{
    public InvalidRoundsException(int repsCount)
        : base($"Invalid reps count: {repsCount}") { }

    public InvalidRoundsException(string message)
        : base(message) { }
}
