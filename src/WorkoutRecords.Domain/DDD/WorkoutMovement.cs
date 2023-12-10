using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain;

public abstract class WorkoutMovement(Movement movement) : ValueObject
{
    public Movement Movement { get; } = movement;
}

// reps (single under, pull ups)
// reps + weight (clean, snatch)
// distance (run, row)
// distance + weight (farmer carry)
