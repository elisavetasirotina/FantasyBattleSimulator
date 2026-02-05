using UseCases;

namespace Entities;

public class CombatAnalyst : IEntity
{
    public AttackIndicator AttackIndicator { get; private set; }

    public HealthIndicator HealthIndicator { get; private set; }

    public CombatAnalyst(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
    {
        HealthIndicator = healthIndicator;
        AttackIndicator = attackIndicator;
    }

    public void Attack(IEntity opponent)
    {
        AttackIndicator.Update(new AttackIndicator(AttackIndicator.Value + 2));
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
        return new CombatAnalyst(new HealthIndicator(HealthIndicator.Value), new AttackIndicator(AttackIndicator.Value));
    }
}