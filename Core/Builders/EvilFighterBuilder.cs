using Entities;

namespace Builders;

public sealed class EvilFighterBuilder : EntityBuilderBase
{
    public EvilFighterBuilder() : base(new HealthIndicator(6), new AttackIndicator(1)) { }

    public override IEntity Build()
    {
        IEntity entity = new EvilFighter(HealthIndicator, AttackIndicator);
        entity = AddModifiers(entity);
        return entity;
    }
}