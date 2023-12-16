using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain;

public abstract class WorkoutMovement(Movement movement) : ValueObject
{
    public Movement Movement { get; } = movement;
}
