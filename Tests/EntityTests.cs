using Builders;
using Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Tests;
using NSubstitute;
using Xunit;

namespace Tests;

public class EntityTests
{
    [Fact]
    public void Should_EditAttackIndicatorCombatAnalyst_Success()
    {
        // Arrange
        IEntity combatAnalyst = new CombatAnalystBuilder().Build();
        IEntity opponent = Substitute.For<IEntity>();

        // Assert
        Assert.Equal(2, combatAnalyst.AttackIndicator.Value);

        // Act
        combatAnalyst.Attack(opponent);

        // Assert
        Assert.Equal(4, combatAnalyst.AttackIndicator.Value);

        // Act
        combatAnalyst.Attack(opponent);

        // Assert
        Assert.Equal(6, combatAnalyst.AttackIndicator.Value);
    }

    [Fact]
    public void Should_EditAttackIndicatorEvilFighter_Success()
    {
        // Arrange
        IEntity evilFighter = new EvilFighterBuilder().Build();

        IEntity opponent = new TestEntityBuilder(new HealthIndicator(10), new AttackIndicator(2)).Build();

        // Assert
        Assert.Equal(1, evilFighter.AttackIndicator.Value);

        // Act
        evilFighter.Accept(opponent);

        // Assert
        Assert.Equal(2, evilFighter.AttackIndicator.Value);

        // Act
        evilFighter.Accept(opponent);

        // Assert
        Assert.Equal(4, evilFighter.AttackIndicator.Value);
    }

    [Fact]
    public void Should_EditIndicatorsMimikChest_Success()
    {
        // Arrange
        IEntity mimikChest = new MimikChestBuilder().Build();
        IEntity opponent = Substitute.For<IEntity>();
        opponent.AttackIndicator.Returns(new AttackIndicator(0));
        opponent.HealthIndicator.Returns(new HealthIndicator(1000));

        // Assert
        Assert.Equal(1, mimikChest.AttackIndicator.Value);

        // Act
        mimikChest.Attack(opponent);

        // Assert
        Assert.Equal(1, mimikChest.AttackIndicator.Value);
        Assert.Equal(1000, mimikChest.HealthIndicator.Value);
    }

    [Fact]
    public void Should_RebornImmortalHorror_Success()
    {
        // Arrange
        IEntity immortalHorror = new ImmortalHorrorBuilder().Build();
        IEntity opponent = new TestEntityBuilder(new HealthIndicator(5), new AttackIndicator(5)).Build();

        // Assert
        Assert.Equal(4, immortalHorror.AttackIndicator.Value);

        // Act
        immortalHorror.Accept(opponent);

        // Assert
        Assert.Equal(4, immortalHorror.AttackIndicator.Value);
        Assert.Equal(1, immortalHorror.HealthIndicator.Value);
        Assert.True(immortalHorror.HealthIndicator.Value > 0);

        // Act
        immortalHorror.Accept(opponent);

        // Assert
        Assert.False(immortalHorror.HealthIndicator.Value > 0);
    }

    [Fact]
    public void Should_AmuletsMasterHasMagicShield_Success()
    {
        // Arrange
        IEntity amuletsMaster = new AmuletsMasterBuilder().Build();
        IEntity opponent = new TestEntityBuilder(new HealthIndicator(0), new AttackIndicator(3)).Build();

        // Act
        amuletsMaster.Accept(opponent);

        // Assert
        Assert.True(amuletsMaster.HealthIndicator.Value > 0);

        // Act
        amuletsMaster.Accept(opponent);

        // Assert
        Assert.False(amuletsMaster.HealthIndicator.Value > 0);
    }

    [Fact]
    public void Should_AmuletsMasterHasAttackSkill_Success()
    {
        // Arrange
        IEntity amuletsMaster = new AmuletsMasterBuilder().Build();
        IEntity opponent = new TestEntityBuilder(new HealthIndicator(6), new AttackIndicator(3)).Build();

        // Act
        amuletsMaster.Attack(opponent);
        opponent.Accept(amuletsMaster);

        // Assert
        Assert.False(opponent.HealthIndicator.Value > 0);
    }
}