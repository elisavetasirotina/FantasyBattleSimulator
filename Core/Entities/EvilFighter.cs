using UseCases;

namespace Entities;

public class EvilFighter : IEntity
{
    public AttackIndicator AttackIndicator { get; private set; }

    public HealthIndicator HealthIndicator { get; private set; }

    public EvilFighter(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
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
            AttackIndicator.Update(new AttackIndicator(AttackIndicator.Value * 2));
            return new AcceptResult.Success();
        }
        else
        {
            return new AcceptResult.Failure();
        }
    }

    public IEntity Clone()
    {
        return new EvilFighter(
            new HealthIndicator(HealthIndicator.Value),
            new AttackIndicator(AttackIndicator.Value));
    }
}