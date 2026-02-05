using Entities;
using UseCases;

namespace Modifiers;

public class AttackSkill : IEntity
{
    public IEntity Entity { get; private set; }

    public AttackIndicator AttackIndicator => Entity.AttackIndicator;

    public HealthIndicator HealthIndicator => Entity.HealthIndicator;

    public AttackSkill(IEntity entity)
    {
        Entity = entity;
    }

    public void Attack(IEntity opponent)
    {
        opponent.Accept(this);
        if (opponent.HealthIndicator.Value > 0)
        {
            opponent.Accept(this);
        }
    }

    public AcceptResult Accept(IEntity opponent)
    {
        AcceptResult result = Entity.Accept(opponent);
        return result;
    }

    public IEntity Clone()
    {
        return new AttackSkill(Entity.Clone());
    }
}