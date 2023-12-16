namespace WorkoutRecords.Domain.DDD;

public class RepsRecord : Record
{
    private RepsRecord(DateOnly date, Reps reps)
        : base(date)
    {
        Reps = reps;
    }

    public Reps Reps { get; }

    public static RepsRecord Set(DateOnly date, int reps) => new(date, Reps.Count(reps));

    public static bool operator <(RepsRecord left, RepsRecord right) => left.Reps < right.Reps;

    public static bool operator >(RepsRecord left, RepsRecord right) => right < left;

    public static bool operator ==(RepsRecord left, RepsRecord right) => EqualOperator(left, right);

    public static bool operator !=(RepsRecord left, RepsRecord right) =>
        NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override bool IsBetterThan(Record other) =>
        other is RepsRecord otherRepsRecord && IsBetterThan(otherRepsRecord);

    public bool IsBetterThan(RepsRecord other) => this > other;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return Reps;
    }
}
