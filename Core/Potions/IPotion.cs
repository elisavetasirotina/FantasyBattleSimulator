using Entities;

namespace Potions;

public interface IPotion
{
    IEntity Apply(IEntity entity);
}