namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidRepsException : DomainException
{
    public InvalidRepsException(int repsCount)
        : base($"Invalid reps count: {repsCount}") { }

    public InvalidRepsException(string message)
        : base(message) { }
}
