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

    public static bool operator ==(RepsRecord left, RepsRecord right) => EqualOperator(left, right);

    public static bool operator !=(RepsRecord left, RepsRecord right) =>
        NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return Reps;
    }
}
