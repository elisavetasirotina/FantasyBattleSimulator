using UseCases;

namespace Entities;

public class ImmortalHorror : IEntity
{
    private bool _reborn;

    public AttackIndicator AttackIndicator { get; private set; }

    public HealthIndicator HealthIndicator { get; private set; }

    public ImmortalHorror(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
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
            if (!_reborn)
            {
                _reborn = true;
                HealthIndicator = new HealthIndicator(1);
                return new AcceptResult.Success();
            }
            else
            {
                return new AcceptResult.Failure();
            }
        }
    }

    public IEntity Clone()
    {
        return new ImmortalHorror(
            new HealthIndicator(HealthIndicator.Value),
            new AttackIndicator(AttackIndicator.Value));
    }
}