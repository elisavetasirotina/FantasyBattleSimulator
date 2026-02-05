namespace Entities;

public record class HealthIndicator
{
    public int Value { get; private set; }

    public HealthIndicator(int value)
    {
        Value = value;
    }

    public void Update(HealthIndicator value)
    {
        if (value.Value < 0)
        {
            value.Value = 0;
        }

        Value = value.Value;
    }
}