using Entities;
using Modifiers;

namespace Potions;

public class ProtectionAmuletPotion : IPotion
{
    public IEntity Apply(IEntity entity)
    {
        var modifierApplier = new MagicShieldApplier();
        return modifierApplier.Apply(entity);
    }
}