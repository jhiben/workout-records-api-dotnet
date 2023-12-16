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

    public static bool operator <(WeightRecord left, WeightRecord right) =>
        left.Weight < right.Weight;

    public static bool operator >(WeightRecord left, WeightRecord right) => right < left;

    public static bool operator ==(WeightRecord left, WeightRecord right) =>
        EqualOperator(left, right);

    public static bool operator !=(WeightRecord left, WeightRecord right) =>
        NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override bool IsBetterThan(Record other) =>
        other is WeightRecord otherWeightRecord && IsBetterThan(otherWeightRecord);

    public bool IsBetterThan(WeightRecord other) => this > other;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return Weight;
    }
}
