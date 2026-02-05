using Entities;

namespace Builders;

public sealed class AmuletsMasterBuilder : EntityBuilderBase
{
    public AmuletsMasterBuilder() : base(new HealthIndicator(2), new AttackIndicator(5)) { }

    public override IEntity Build()
    {
        WithAttackSkill().WithMagicShield();
        IEntity entity = new AmuletsMaster(HealthIndicator, AttackIndicator);
        entity = AddModifiers(entity);
        return entity;
    }
}