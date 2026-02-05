using Entities;

namespace Potions;

public class AttackPotion : IPotion
{
    public IEntity Apply(IEntity entity)
    {
        entity.AttackIndicator.Update(new AttackIndicator(entity.AttackIndicator.Value + 5));
        return entity;
    }
}