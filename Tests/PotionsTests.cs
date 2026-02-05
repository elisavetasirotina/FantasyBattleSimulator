using Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Tests;
using Potions;
using Table;
using Xunit;

namespace Tests;

public class PotionsTests
{
    [Fact]
    public void Should_HealthPotion_Success()
    {
        for (int i = 0; i < 100; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                // Arrange
                var table = new PlayerTable();
                IEntity entity = new TestEntityBuilder(new HealthIndicator(i), new AttackIndicator(j)).Build();
                table.AddEntity(entity);
                table.ApplyPotion(new HealthPotion(), table.Entities.First());

                // Assert
                Assert.Equal(i + 5, table.Entities.First().HealthIndicator.Value);
            }
        }
    }

    [Fact]
    public void Should_AttackPotion_Success()
    {
        for (int i = 0; i < 100; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                // Arrange
                var table = new PlayerTable();
                IEntity entity = new TestEntityBuilder(new HealthIndicator(i), new AttackIndicator(j)).Build();
                table.AddEntity(entity);
                table.ApplyPotion(new AttackPotion(), table.Entities.First());

                // Assert
                Assert.Equal(j + 5, table.Entities.First().AttackIndicator.Value);
            }
        }
    }

    [Fact]
    public void Should_MagicMirror_Success()
    {
        for (int i = 0; i < 100; ++i)
        {
            for (int j = 0; j < 100; ++j)
            {
                // Arrange
                var table = new PlayerTable();
                IEntity entity = new TestEntityBuilder(new HealthIndicator(i), new AttackIndicator(j)).Build();
                table.AddEntity(entity);
                table.ApplyPotion(new MagicMirrorPotion(), table.Entities.First());

                // Assert
                Assert.Equal(j, table.Entities.First().HealthIndicator.Value);
                Assert.Equal(i, table.Entities.First().AttackIndicator.Value);
            }
        }
    }

    [Fact]
    public void Should_ProtectionAmulet_Success()
    {
        // Arrange
        IEntity testEntity2 = new TestEntityBuilder(new HealthIndicator(2), new AttackIndicator(2)).Build();
        IEntity testEntity1 = new TestEntityBuilder(new HealthIndicator(1), new AttackIndicator(1)).Build();
        var table1 = new PlayerTable();
        var table2 = new PlayerTable();

        // Act
        table1.AddEntity(testEntity1);
        table2.AddEntity(testEntity2);
        table1.ApplyPotion(new ProtectionAmuletPotion(), table1.Entities.First());
        table1.Entities.First().Accept(testEntity2);

        // Assert
        Assert.True(table1.Entities.First().HealthIndicator.Value > 0);
    }
}