using Entities;
using UseCases;

namespace Modifiers;

public class MagicShield : IEntity
{
    public IEntity Entity { get; private set; }

    public bool Exist { get; private set; }

    public AttackIndicator AttackIndicator => Entity.AttackIndicator;

    public HealthIndicator HealthIndicator => Entity.HealthIndicator;

    public MagicShield(IEntity entity)
    {
        Entity = entity;
        Exist = true;
    }

    public void Attack(IEntity opponent)
    {
        Entity.Attack(opponent);
    }

    public AcceptResult Accept(IEntity opponent)
    {
        if (Exist)
        {
            Exist = false;
            return new AcceptResult.Success();
        }
        else
        {
            AcceptResult result = Entity.Accept(opponent);
            return result;
        }
    }

    public IEntity Clone()
    {
        return new MagicShield(Entity.Clone());
    }
}