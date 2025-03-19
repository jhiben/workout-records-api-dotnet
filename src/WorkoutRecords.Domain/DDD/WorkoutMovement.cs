using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace WorkoutRecords.Domain;

public abstract class WorkoutMovement(Movement movement) : ValueObject
{
    public Movement Movement { get; } = movement;
    public DbSet<WorkoutMovement> WorkoutMovements { get; set; }
}
