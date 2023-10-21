using WorkoutRecords.Domain.CRUD;

namespace WorkoutRecords.Domain.UnitTests;

public class RecordTests
{
    [Fact]
    public void WorkoutRecord_CanModelRealWod_Murph()
    {
        // Given
        var murph = new Workout
        {
            RoundsCount = 1,
            TimeCap = TimeSpan.FromMinutes(60),
            Movements = new()
            {
                new()
                {
                    Movement = new() { Name = "Run", Description = "Run 1 mile" },
                    Distance = 1
                },
                new()
                {
                    Movement = new() { Name = "Pull-ups", Description = "Pull-ups" },
                    RepsCount = 100
                },
                new()
                {
                    Movement = new() { Name = "Push-ups", Description = "Push-ups" },
                    RepsCount = 200
                },
                new()
                {
                    Movement = new() { Name = "Squats", Description = "Squats" },
                    RepsCount = 300
                },
                new()
                {
                    Movement = new() { Name = "Run", Description = "Run 1 mile" },
                    Distance = 1
                }
            }
        };

        // When
        var record = new WorkoutRecord
        {
            Workout = murph,
            Time = TimeSpan.FromMinutes(45),
            RepsCount = 600
        };

        // Then
        Assert.Equal(murph, record.Workout);
    }

    [Fact]
    public void WorkoutRecord_CanModelRealWod_Fran()
    {
        // Given
        var fran = new Workout
        {
            RoundsCount = 1,
            TimeCap = TimeSpan.FromMinutes(10),
            Movements = new()
            {
                new()
                {
                    Movement = new() { Name = "Thrusters", Description = "Thrusters" },
                    RepsCount = 21,
                    Weight = 95,
                },
                new()
                {
                    Movement = new() { Name = "Pull-ups", Description = "Pull-ups" },
                    RepsCount = 21,
                },
                new()
                {
                    Movement = new() { Name = "Thrusters", Description = "Thrusters" },
                    RepsCount = 15,
                    Weight = 95,
                },
                new()
                {
                    Movement = new() { Name = "Pull-ups", Description = "Pull-ups" },
                    RepsCount = 15,
                },
                new()
                {
                    Movement = new() { Name = "Thrusters", Description = "Thrusters" },
                    RepsCount = 9,
                    Weight = 95,
                },
                new()
                {
                    Movement = new() { Name = "Pull-ups", Description = "Pull-ups" },
                    RepsCount = 9,
                },
            },
        };

        // When
        var record = new WorkoutRecord
        {
            Workout = fran,
            Time = TimeSpan.FromMinutes(5),
            RepsCount = 90
        };

        // Then
        Assert.Equal(fran, record.Workout);
    }
}
