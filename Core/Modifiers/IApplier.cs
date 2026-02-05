using Entities;

namespace Modifiers;

public interface IApplier
{
    IEntity Apply(IEntity entity);
}