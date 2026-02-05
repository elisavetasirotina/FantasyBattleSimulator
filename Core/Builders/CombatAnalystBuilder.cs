using Entities;

namespace Builders;

public sealed class CombatAnalystBuilder : EntityBuilderBase
{
    public CombatAnalystBuilder() : base(new HealthIndicator(4), new AttackIndicator(2)) { }

    public override IEntity Build()
    {
        IEntity entity = new CombatAnalyst(HealthIndicator, AttackIndicator);
        entity = AddModifiers(entity);
        return entity;
    }
}