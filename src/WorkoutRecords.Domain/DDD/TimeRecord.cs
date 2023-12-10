namespace WorkoutRecords.Domain.DDD;

public class TimeRecord : Record
{
    private TimeRecord(DateOnly date, Time time)
        : base(date)
    {
        Time = time;
    }

    public Time Time { get; }

    public static TimeRecord Set(DateOnly date, TimeSpan time) => new(date, Time.Track(time));

    public static bool operator <(TimeRecord left, TimeRecord right) =>
        (TimeSpan)left.Time < right.Time;

    public static bool operator >(TimeRecord left, TimeRecord right) => right < left;

    public static bool operator ==(TimeRecord left, TimeRecord right) => EqualOperator(left, right);

    public static bool operator !=(TimeRecord left, TimeRecord right) =>
        NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override bool IsBetterThan(Record other) =>
        other is TimeRecord otherTimeRecord && IsBetterThan(otherTimeRecord);

    public bool IsBetterThan(TimeRecord other) => this < other;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
        yield return Time;
    }
}
