namespace WorkoutRecords.Domain.DDD;

public class RecordBuilder
{
    private readonly DateOnly _date;

    internal RecordBuilder(DateOnly date)
    {
        _date = date;
    }

    public RepsRecord WithReps(int reps) => RepsRecord.Set(_date, reps);

    public TimeRecord WithTime(TimeSpan time) => TimeRecord.Set(_date, time);

    public WeightRecord WithWeight(int weight) => WeightRecord.Set(_date, weight);
}
