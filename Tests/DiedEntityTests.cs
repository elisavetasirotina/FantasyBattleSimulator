using Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Tests;
using Table;
using Xunit;

namespace Tests;

public class DiedEntityTests
{
    [Fact]
    public void Should_AttackWithNullHealth_Failure()
    {
        // Arrange
        var entity = new TestEntityBuilder(new HealthIndicator(0), new AttackIndicator(100)).Build();
        var table = new PlayerTable();

        // Act
        table.AddEntity(entity);
        IEntity? attackEntity = table.FindAttackEntity();

        // Assert
        Assert.Null(attackEntity);
    }

    [Fact]
    public void Should_AttackWithNullAttack_Failure()
    {
        // Arrange
        IEntity entity = new TestEntityBuilder(new HealthIndicator(100), new AttackIndicator(0)).Build();
        var table = new PlayerTable();

        // Act
        table.AddEntity(entity);
        IEntity? attackEntity = table.FindAttackEntity();

        // Assert
        Assert.Null(attackEntity);
    }

    [Fact]
    public void Should_AcceptWithNullHealth_Failure()
    {
        // Arrange
        IEntity entity = new TestEntityBuilder(new HealthIndicator(0), new AttackIndicator(0)).Build();
        var table = new PlayerTable();

        // Act
        table.AddEntity(entity);
        IEntity? acceptEntity = table.FindAcceptEntity();

        // Assert
        Assert.Null(acceptEntity);
    }
}