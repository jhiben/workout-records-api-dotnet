namespace WorkoutRecords.Domain.DDD;

public class RecordBuilder
{
    private readonly DateOnly _date;

    internal RecordBuilder(DateOnly date)
    {
        _date = date;
    }

    public Record WithReps(int reps) => RepsRecord.Set(_date, reps);

    public Record WithTime(TimeSpan time) => TimeRecord.Set(_date, time);

    public Record WithWeight(int weight) => WeightRecord.Set(_date, weight);
}
