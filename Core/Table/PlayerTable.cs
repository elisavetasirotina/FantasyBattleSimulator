using Entities;
using Potions;
using UseCases;

namespace Table;

public class PlayerTable : IPlayerTable
{
    private readonly List<IEntity> _entities = new List<IEntity>();

    public IEntity? FindAcceptEntity()
    {
        return Entities.FirstOrDefault(entity => entity.HealthIndicator.Value > 0);
    }

    public IEntity? FindAttackEntity()
    {
        return Entities.FirstOrDefault(entity => entity.HealthIndicator.Value > 0 && entity.AttackIndicator.Value > 0);
    }

    public IReadOnlyCollection<IEntity> Entities => _entities.AsReadOnly();

    public void ApplyPotion(IPotion potion, IEntity entity)
    {
        int index = _entities.IndexOf(entity);
        if (index >= 0)
        {
            _entities[index] = potion.Apply(_entities[index]);
            return;
        }
    }

    public PlayerTable() { }

    public TableResult AddEntity(IEntity entity)
    {
        if (_entities.Count < 7)
        {
            _entities.Add(entity.Clone());
            return new TableResult.Success();
        }

        return new TableResult.EntitiesLimitError();
    }
}