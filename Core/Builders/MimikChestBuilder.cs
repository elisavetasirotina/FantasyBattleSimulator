using Entities;

namespace Builders;

public sealed class MimikChestBuilder : EntityBuilderBase
{
    public MimikChestBuilder() : base(new HealthIndicator(1), new AttackIndicator(1)) { }

    public override IEntity Build()
    {
        IEntity entity = new MimikChest(HealthIndicator, AttackIndicator);
        entity = AddModifiers(entity);
        return entity;
    }
}