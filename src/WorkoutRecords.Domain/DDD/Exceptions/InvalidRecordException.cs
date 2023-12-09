namespace WorkoutRecords.Domain.Exceptions;

public class InvalidRecordException(string message) : DomainException(message) { }
