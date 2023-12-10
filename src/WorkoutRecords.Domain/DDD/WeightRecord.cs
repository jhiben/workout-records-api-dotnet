namespace WorkoutRecords.Domain.DDD;

public class WeightRecord : Record
{
    private WeightRecord(DateOnly date, Weight weight)
        : base(date)
    {
        Weight = weight;
    }

    public Weight Weight { get; }

    public static WeightRecord Set(DateOnly date, int weight) =>
        new(date, Weight.InKilograms(weight));
}
