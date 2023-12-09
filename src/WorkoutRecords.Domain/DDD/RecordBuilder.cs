namespace WorkoutRecords.Domain;

public class RecordBuilder
{
    private readonly Guid _workoutId;

    private readonly DateTimeOffset _date;

    internal RecordBuilder(Guid workoutId, DateTimeOffset date)
    {
        _workoutId = workoutId;
        _date = date;
    }

    public Record WithReps(int reps) => RepsRecord.Create(_workoutId, _date, reps);

    public Record WithTime(TimeSpan time) => TimeRecord.Create(_workoutId, _date, time);

    public Record WithWeight(int weight) => WeightRecord.Create(_workoutId, _date, weight);
}
