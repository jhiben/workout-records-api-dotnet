namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidNameException(string message) : DomainException(message) { }
