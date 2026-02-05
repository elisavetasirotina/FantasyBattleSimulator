using Entities;
using Builders;

namespace Tests;

public sealed class TestEntityBuilder : EntityBuilderBase
{
    public TestEntityBuilder(HealthIndicator healthIndicator, AttackIndicator attackIndicator) : base(healthIndicator, attackIndicator) { }

    public override IEntity Build()
    {
        IEntity entity = new TestEntity(HealthIndicator, AttackIndicator);
        entity = AddModifiers(entity);
        return entity;
    }
}