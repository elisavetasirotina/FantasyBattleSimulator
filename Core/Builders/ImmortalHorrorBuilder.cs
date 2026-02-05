using Entities;

namespace Builders;

public sealed class ImmortalHorrorBuilder : EntityBuilderBase
{
    public ImmortalHorrorBuilder() : base(new HealthIndicator(4), new AttackIndicator(4)) { }

    public override IEntity Build()
    {
        IEntity entity = new ImmortalHorror(HealthIndicator, AttackIndicator);
        entity = AddModifiers(entity);
        return entity;
    }
}