using Entities;
using UseCases;

namespace Tests;

public class TestEntity : IEntity
{
    public TestEntity(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
    {
        HealthIndicator = healthIndicator;
        AttackIndicator = attackIndicator;
    }

    public IEntity Clone()
    {
        return new TestEntity(
            new HealthIndicator(HealthIndicator.Value),
            new AttackIndicator(AttackIndicator.Value));
    }

    public void Attack(IEntity opponent)
    {
        opponent.Accept(this);
    }

    public AcceptResult Accept(IEntity opponent)
    {
        var hit = new HealthIndicator(HealthIndicator.Value - opponent.AttackIndicator.Value);
        HealthIndicator.Update(hit);
        if (HealthIndicator.Value > 0)
        {
            return new AcceptResult.Success();
        }
        else
        {
            return new AcceptResult.Failure();
        }
    }

    public AttackIndicator AttackIndicator { get; private set; }

    public HealthIndicator HealthIndicator { get; private set; }
}