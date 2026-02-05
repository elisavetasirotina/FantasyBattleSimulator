using Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Tests;
using Xunit;

namespace Tests;

public class ModifierTests
{
    [Fact]
    public void Should_KillEntityWithMagicShield_Failure()
    {
        // Arrange
        IEntity testEntity2 = new TestEntityBuilder(new HealthIndicator(2), new AttackIndicator(2)).Build();
        IEntity testEntity1 = new TestEntityBuilder(new HealthIndicator(1), new AttackIndicator(1)).WithMagicShield().Build();

        // Act
        testEntity1.Accept(testEntity2);

        // Assert
        Assert.True(testEntity1.HealthIndicator.Value > 0);
    }

    [Fact]
    public void Should_DoubleKillEntityWithMagicShield_Success()
    {
        // Arrange
        IEntity testEntity2 = new TestEntityBuilder(new HealthIndicator(2), new AttackIndicator(2)).Build();
        IEntity testEntity1 = new TestEntityBuilder(new HealthIndicator(1), new AttackIndicator(1)).WithMagicShield().Build();

        // Act
        testEntity1.Accept(testEntity2);
        testEntity1.Accept(testEntity2);

        // Assert
        Assert.False(testEntity1.HealthIndicator.Value > 0);
    }

    [Fact]
    public void Should_DoubleKillEntityWithTwoMagicShield_Failure()
    {
        // Arrange
        IEntity testEntity2 = new TestEntityBuilder(new HealthIndicator(2), new AttackIndicator(2)).Build();
        IEntity testEntity1 = new TestEntityBuilder(new HealthIndicator(1), new AttackIndicator(1)).WithMagicShield().WithMagicShield().Build();

        // Act
        testEntity1.Accept(testEntity2);
        testEntity1.Accept(testEntity2);

        // Assert
        Assert.True(testEntity1.HealthIndicator.Value > 0);
    }

    [Fact]
    public void Should_DoubleKillWithAttackSkill_Success()
    {
        // Arrange
        IEntity testEntity2 = new TestEntityBuilder(new HealthIndicator(1), new AttackIndicator(4)).Build();
        IEntity testEntity1 = new TestEntityBuilder(new HealthIndicator(1), new AttackIndicator(1)).WithAttackSkill().Build();

        // Act
        testEntity1.Attack(testEntity2);
        testEntity2.Accept(testEntity1);

        // Assert
        Assert.False(testEntity2.HealthIndicator.Value > 0);
    }
}