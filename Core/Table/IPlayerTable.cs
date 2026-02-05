using Entities;
using Potions;
using UseCases;

namespace Table;

public interface IPlayerTable
{
    TableResult AddEntity(IEntity entity);

    IReadOnlyCollection<IEntity> Entities { get; }

    void ApplyPotion(IPotion potion, IEntity entity);

    IEntity? FindAttackEntity();

    IEntity? FindAcceptEntity();
}