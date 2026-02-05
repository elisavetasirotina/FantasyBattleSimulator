namespace Entities;

public record class AttackIndicator
{
    public int Value { get; private set; }

    public AttackIndicator(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("AttackIndicator cannot be negative.");
        }

        Value = value;
    }

    public void Update(AttackIndicator value)
    {
        if (value.Value < 0)
        {
            value.Value = 0;
        }

        Value = value.Value;
    }
}