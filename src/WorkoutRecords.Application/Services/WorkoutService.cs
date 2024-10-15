using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Persistence.Repositories;

namespace WorkoutRecords.Application.Services;

public class WorkoutService
{
    private readonly WorkoutRepository _workoutRepository;

    public WorkoutService(WorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task CreateWorkoutAsync(string name, TimeSpan timeCap, int rounds, CancellationToken cancellationToken = default)
    {
        var workout = Workout.Prepare(Name.Of(name), Time.Track(timeCap), Rounds.Count(rounds));
        await _workoutRepository.SaveAsync(workout, cancellationToken);
    }

    public async Task<Workout?> GetWorkoutByIdAsync(WorkoutId id, CancellationToken cancellationToken = default)
    {
        return await _workoutRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task AddMovementToWorkoutAsync(WorkoutId workoutId, WorkoutMovement movement, CancellationToken cancellationToken = default)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId, cancellationToken);
        if (workout == null)
        {
            throw new InvalidOperationException("Workout not found.");
        }

        workout.Comprise(movement);
        await _workoutRepository.SaveAsync(workout, cancellationToken);
    }
}
