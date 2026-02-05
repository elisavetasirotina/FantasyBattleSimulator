using Entities;

namespace Modifiers;

public class MagicShieldApplier : IApplier
{
    public IEntity Apply(IEntity entity)
    {
        entity = new MagicShield(entity);
        return entity;
    }
}