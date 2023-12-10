using WorkoutRecords.Domain.DDD;

namespace WorkoutRecords.Domain.UnitTests.DDD;

public class WorkoutTests
{
    [Fact]
    public void Workout_Create_Murph()
    {
        // Given
        var name = Name.Of("Murph");
        var timeCap = Time.Track(TimeSpan.FromMinutes(60));
        var rounds = Rounds.Count(1);
        var workout = Workout.Create(name, timeCap, rounds);

        // When
        workout.Comprise(DistanceWorkoutMovement.Define(Movement.Run, 1600));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PullUp, 100));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PushUp, 200));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.Squat, 300));
        workout.Comprise(DistanceWorkoutMovement.Define(Movement.Run, 1600));

        // Then
        workout.Name.Should().Be(name);
        workout.TimeCap.Should().Be(timeCap);
        workout.Rounds.Should().Be(rounds);
        workout.Movements.Should().HaveCount(5);
        workout.Movements[0].Should().BeOfType<DistanceWorkoutMovement>();
        workout.Movements[1].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[2].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[3].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[4].Should().BeOfType<DistanceWorkoutMovement>();
    }

    [Fact]
    public void Workout_Create_Fran()
    {
        // Given
        var name = Name.Of("Fran");
        var timeCap = Time.Track(TimeSpan.FromMinutes(10));
        var rounds = Rounds.Count(3);
        var workout = Workout.Create(name, timeCap, rounds);

        // When
        workout.Comprise(RepsWeightWorkoutMovement.Define(Movement.Thruster, 21, 42));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PullUp, 21));
        workout.Comprise(RepsWeightWorkoutMovement.Define(Movement.Thruster, 15, 42));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PullUp, 15));
        workout.Comprise(RepsWeightWorkoutMovement.Define(Movement.Thruster, 9, 42));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PullUp, 9));

        // Then
        workout.Name.Should().Be(name);
        workout.TimeCap.Should().Be(timeCap);
        workout.Rounds.Should().Be(rounds);
        workout.Movements.Should().HaveCount(6);
        workout.Movements[0].Should().BeOfType<RepsWeightWorkoutMovement>();
        workout.Movements[1].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[2].Should().BeOfType<RepsWeightWorkoutMovement>();
        workout.Movements[3].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[4].Should().BeOfType<RepsWeightWorkoutMovement>();
        workout.Movements[5].Should().BeOfType<RepsWorkoutMovement>();
    }

    [Fact]
    public void Workout_Create_Cindy()
    {
        // Given
        var name = Name.Of("Cindy");
        var timeCap = Time.Track(TimeSpan.FromMinutes(20));
        var rounds = Rounds.AMRAP;
        var workout = Workout.Create(name, timeCap, rounds);

        // When
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PullUp, 5));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.PushUp, 10));
        workout.Comprise(RepsWorkoutMovement.Define(Movement.Squat, 15));

        // Then
        workout.Name.Should().Be(name);
        workout.TimeCap.Should().Be(timeCap);
        workout.Rounds.Should().Be(rounds);
        workout.Movements.Should().HaveCount(3);
        workout.Movements[0].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[1].Should().BeOfType<RepsWorkoutMovement>();
        workout.Movements[2].Should().BeOfType<RepsWorkoutMovement>();
    }
}
