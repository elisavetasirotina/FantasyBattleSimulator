using Entities;
using Modifiers;

namespace Builders;

public abstract class EntityBuilderBase
{
    private readonly List<IApplier> _modifiers = new List<IApplier>();

    protected HealthIndicator HealthIndicator { get; set; }

    protected AttackIndicator AttackIndicator { get; set; }

    protected IEntity AddModifiers(IEntity entity)
    {
        return _modifiers.Aggregate(entity, (entity, modifier) => modifier.Apply(entity));
    }

    protected EntityBuilderBase(HealthIndicator healthIndicator, AttackIndicator attackIndicator)
    {
        HealthIndicator = healthIndicator;
        AttackIndicator = attackIndicator;
    }

    public abstract IEntity Build();

    public EntityBuilderBase WithAttackSkill()
    {
        _modifiers.Add(new AttackSkillApplier());
        return this;
    }

    public EntityBuilderBase WithMagicShield()
    {
        _modifiers.Add(new MagicShieldApplier());
        return this;
    }
}