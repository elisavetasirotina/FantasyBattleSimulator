using UseCases;

namespace Entities;

public class AmuletsMaster : IEntity
{
    public AttackIndicator AttackIndicator { get; private set; }

    public HealthIndicator HealthIndicator { get; private set; }

    public AmuletsMaster(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
    {
        HealthIndicator = healthIndicator;
        AttackIndicator = attackIndicator;
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

    public IEntity Clone()
    {
        return new AmuletsMaster(
            new HealthIndicator(HealthIndicator.Value),
            new AttackIndicator(AttackIndicator.Value));
    }
}