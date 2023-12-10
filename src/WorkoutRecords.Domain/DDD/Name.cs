using WorkoutRecords.Domain.DDD.Exceptions;
using WorkoutRecords.Domain.DDD.SeedWork;

namespace WorkoutRecords.Domain.DDD;

public class Name : ValueObject
{
    private const int _minLength = 3;

    private const int _maxLength = 50;

    private readonly string _value;

    private Name(string value) => _value = value;

    public static Name Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidNameException("Name must not be empty.");
        }

        if (value.Length < _minLength)
        {
            throw new InvalidNameException($"Name must be at least {_minLength} characters long.");
        }

        if (value.Length > _maxLength)
        {
            throw new InvalidNameException($"Name must be at most {_maxLength} characters long.");
        }

        return new(value);
    }

    public static implicit operator string(Name name) => name._value;

    public static explicit operator Name(string value) => Of(value);

    public static bool operator ==(Name left, Name right) => EqualOperator(left, right);

    public static bool operator !=(Name left, Name right) => NotEqualOperator(left, right);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => _value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }
}
