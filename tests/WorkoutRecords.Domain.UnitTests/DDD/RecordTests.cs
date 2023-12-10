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
        var reps = Reps.Count(10);

        // When
        var record = Record.SetOn(date).WithReps(reps);

        // Then
        record.Should().BeOfType<RepsRecord>().Which.Reps.Should().Be(reps);
    }

    [Fact]
    public void Create_Weight_Record()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var weight = Weight.InKilograms(100);

        // When
        var record = Record.SetOn(date).WithWeight(weight);

        // Then
        record.Should().BeOfType<WeightRecord>().Which.Weight.Should().Be(weight);
    }

    [Fact]
    public void Create_Time_Record()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var time = Time.Track(TimeSpan.FromMinutes(10));

        // When
        var record = Record.SetOn(date).WithTime(time);

        // Then
        record.Should().BeOfType<TimeRecord>().Which.Time.Should().Be(time);
    }

    [Fact]
    public void Reps_Compare_Equal()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var reps = Reps.Count(10);
        var record1 = Record.SetOn(date).WithReps(reps);
        var record2 = Record.SetOn(date).WithReps(reps);

        // When
        var result = record1 == record2;

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public void Reps_Compare_NotEqual()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var reps1 = Reps.Count(10);
        var reps2 = Reps.Count(20);
        var record1 = Record.SetOn(date).WithReps(reps1);
        var record2 = Record.SetOn(date).WithReps(reps2);

        // When
        var result = record1 == record2;

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public void Weight_Compare_Equal()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var weight = Weight.InKilograms(100);
        var record1 = Record.SetOn(date).WithWeight(weight);
        var record2 = Record.SetOn(date).WithWeight(weight);

        // When
        var result = record1 == record2;

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public void Weight_Compare_NotEqual()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var weight1 = Weight.InKilograms(100);
        var weight2 = Weight.InKilograms(200);
        var record1 = Record.SetOn(date).WithWeight(weight1);
        var record2 = Record.SetOn(date).WithWeight(weight2);

        // When
        var result = record1 == record2;

        // Then
        result.Should().BeFalse();
    }

    [Fact]
    public void Time_Compare_Equal()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var time = Time.Track(TimeSpan.FromMinutes(10));
        var record1 = Record.SetOn(date).WithTime(time);
        var record2 = Record.SetOn(date).WithTime(time);

        // When
        var result = record1 == record2;

        // Then
        result.Should().BeTrue();
    }

    [Fact]
    public void Time_Compare_NotEqual()
    {
        // Given
        var date = DateOnly.FromDateTime(DateTime.UtcNow);
        var time1 = Time.Track(TimeSpan.FromMinutes(10));
        var time2 = Time.Track(TimeSpan.FromMinutes(20));
        var record1 = Record.SetOn(date).WithTime(time1);
        var record2 = Record.SetOn(date).WithTime(time2);

        // When
        var result = record1 == record2;

        // Then
        result.Should().BeFalse();
    }
}
