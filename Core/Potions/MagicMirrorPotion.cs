using Entities;

namespace Potions;

public class MagicMirrorPotion : IPotion
{
    public IEntity Apply(IEntity entity)
    {
        int healthIndicator = entity.HealthIndicator.Value;
        entity.HealthIndicator.Update(new HealthIndicator(entity.AttackIndicator.Value));
        entity.AttackIndicator.Update(new AttackIndicator(healthIndicator));
        return entity;
    }
}