using Entities;

namespace Potions;

public class HealthPotion : IPotion
{
    public IEntity Apply(IEntity entity)
    {
        entity.HealthIndicator.Update(new HealthIndicator(entity.HealthIndicator.Value + 5));
        return entity;
    }
}