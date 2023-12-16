using WorkoutRecords.Domain.DDD;

namespace WorkoutRecords.Domain.UnitTests.DDD;

public class WorkoutMovementTests
{
    [Fact]
    public void DistanceMovement_ToString_Ok()
    {
        // Given
        var movement = Movement.Run;
        var distance = Distance.InMeters(100);

        // When
        var workout = DistanceWorkoutMovement.Define(movement, distance);

        // Then
        workout.ToString().Should().Be("Run - 100m");
    }

    [Fact]
    public void DistanceWeightMovement_ToString_Ok()
    {
        // Given
        var movement = Movement.FarmersCarry;
        var distance = Distance.InMeters(100);
        var weight = Weight.InKilograms(100);

        // When
        var workout = DistanceWeightWorkoutMovement.Define(movement, distance, weight);

        // Then
        workout.ToString().Should().Be("Farmer's Carry - 100m at 100kg");
    }

    [Fact]
    public void RepsMovement_ToString_Ok()
    {
        // Given
        var movement = Movement.PullUp;
        var reps = Reps.Count(10);

        // When
        var workout = RepsWorkoutMovement.Define(movement, reps);

        // Then
        workout.ToString().Should().Be("Pull-Up - 10 reps");
    }

    [Fact]
    public void RepsWeightMovement_ToString_Ok()
    {
        // Given
        var movement = Movement.Clean;
        var reps = Reps.Count(10);
        var weight = Weight.InKilograms(100);

        // When
        var workout = RepsWeightWorkoutMovement.Define(movement, reps, weight);

        // Then
        workout.ToString().Should().Be("Clean - 10 reps at 100kg");
    }
}
