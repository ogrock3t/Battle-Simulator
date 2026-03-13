namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record Health
{
    public int Value { get; }

    public Health(int value)
    {
        if (value < 0)
            throw new ArgumentException("Health value cannot be negative", nameof(value));

        Value = value;
    }
}