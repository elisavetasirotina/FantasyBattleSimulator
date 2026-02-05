using Entities;

namespace Modifiers;

public class AttackSkillApplier : IApplier
{
    public IEntity Apply(IEntity entity)
    {
        entity = new AttackSkill(entity);
        return entity;
    }
}