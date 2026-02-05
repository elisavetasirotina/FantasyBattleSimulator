using UseCases;

namespace Entities;

public class MimikChest : IEntity
{
    public AttackIndicator AttackIndicator { get; private set; }

    public HealthIndicator HealthIndicator { get; private set; }

    public MimikChest(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
    {
        HealthIndicator = healthIndicator;
        AttackIndicator = attackIndicator;
    }

    public void Attack(IEntity opponent)
    {
        HealthIndicator.Update(new HealthIndicator(Math.Max(opponent.HealthIndicator.Value, HealthIndicator.Value)));
        AttackIndicator.Update(new AttackIndicator(Math.Max(opponent.AttackIndicator.Value, AttackIndicator.Value)));
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
        return new MimikChest(
            new HealthIndicator(HealthIndicator.Value),
            new AttackIndicator(AttackIndicator.Value));
    }
}