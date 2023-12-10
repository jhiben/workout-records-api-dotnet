using WorkoutRecords.Domain.DDD;
using Record = WorkoutRecords.Domain.DDD.Record;

namespace WorkoutRecords.Domain.UnitTests.DDD;

public class RecordTests
{
    [Fact]
    public void Create_Reps_Record()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var reps = 10;

        // When
        var record = Record.Create(date).WithReps(reps);

        // Then
        record.Should().BeOfType<RepsRecord>().Which.Reps.Should().Be(reps);
    }

    [Fact]
    public void Create_Weight_Record()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var weight = 10;

        // When
        var record = Record.Create(date).WithWeight(weight);

        // Then
        record.Should().BeOfType<WeightRecord>().Which.Weight.Should().Be(weight);
    }

    [Fact]
    public void Create_Time_Record()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var time = TimeSpan.FromMinutes(10);

        // When
        var record = Record.Create(date).WithTime(time);

        // Then
        record.Should().BeOfType<TimeRecord>().Which.Time.Should().Be(time);
    }
}
