namespace WorkoutRecords.Domain.DDD.Exceptions;

public class InvalidRecordException(string message) : DomainException(message) { }
