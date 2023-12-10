using WorkoutRecords.Domain.DDD;
using WorkoutRecords.Domain.DDD.Exceptions;
using Record = WorkoutRecords.Domain.DDD.Record;

namespace WorkoutRecords.Domain.UnitTests.DDD;

public class RecordHistoryTests
{
    [Fact]
    public void Reps_Add_Added()
    {
        // Given
        var workoutId = WorkoutId.New();
        var history = new RepsRecordHistory(workoutId);
        var record = Record.SetOn(DateOnly.FromDateTime(DateTime.UtcNow)).WithReps(Reps.Count(10));

        // When
        history.SetNew(record);

        // Then
        history.Records.Should().Contain(record);
    }

    [Fact]
    public void Reps_Add_InvalidAfter()
    {
        // Given
        var workoutId = WorkoutId.New();
        var history = new RepsRecordHistory(workoutId);
        var record1 = Record.SetOn(DateOnly.FromDateTime(DateTime.UtcNow)).WithReps(Reps.Count(10));
        var record2 = Record
            .SetOn(DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)))
            .WithReps(Reps.Count(15));

        // When
        history.SetNew(record1);

        // Then
        history.Invoking(h => h.SetNew(record2)).Should().Throw<InvalidRecordException>();
    }

    [Fact]
    public void Reps_Add_InvalidBetter()
    {
        // Given
        var workoutId = WorkoutId.New();
        var history = new RepsRecordHistory(workoutId);
        var record1 = Record
            .SetOn(DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)))
            .WithReps(Reps.Count(10));
        var record2 = Record.SetOn(DateOnly.FromDateTime(DateTime.UtcNow)).WithReps(Reps.Count(5));

        // When
        history.SetNew(record1);

        // Then
        history.Invoking(h => h.SetNew(record2)).Should().Throw<InvalidRecordException>();
    }

    [Fact]
    public void Id_GetHashCode_Different()
    {
        // Given
        var workoutId = WorkoutId.New();
        var history1 = new RepsRecordHistory(workoutId);
        var history2 = new RepsRecordHistory(workoutId);

        // When
        var result = history1.Id.GetHashCode() == history2.Id.GetHashCode();

        // Then
        result.Should().BeFalse();
    }
}
