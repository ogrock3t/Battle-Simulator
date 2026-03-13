namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record Attack
{
    public int Value { get; }

    public Attack(int value)
    {
        if (value < 0)
            throw new ArgumentException("Attack point cannot be negative", nameof(value));

        Value = value;
    }
}