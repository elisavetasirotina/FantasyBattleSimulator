using UseCases;

namespace Entities;

public interface IEntity : IPrototype
{
    void Attack(IEntity opponent);

    AcceptResult Accept(IEntity opponent);

    AttackIndicator AttackIndicator { get; }

    HealthIndicator HealthIndicator { get; }
}