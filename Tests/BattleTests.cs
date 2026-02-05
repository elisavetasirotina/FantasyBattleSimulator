using Battle;
using Builders;
using Entities;
using Table;
using UseCases;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class BattleTests
{
    [Fact]
    public void Should_AmuletsMasterWinCombatAnalyst_Success()
    {
        // Arrange
        IEntity amuletsMaster = new AmuletsMasterBuilder().Build();
        IEntity combatAnalyst = new CombatAnalystBuilder().Build();
        var table1 = new PlayerTable();
        var table2 = new PlayerTable();
        BattleFacade battle = BattleFacade.Create;

        // Act
        table1.AddEntity(combatAnalyst);
        table2.AddEntity(amuletsMaster);
        BattleResult winner = battle.PlayersBattle(table1, table2);
        var winnerTable = (BattleResult.Win)winner;

        // Assert
        Assert.IsType<BattleResult.Win>(winner);
        Assert.Equal(table2, winnerTable.Table);
    }

    [Fact]
    public void Should_EvilFighterWinMimikChestSuccess()
    {
        // Arrange
        IEntity evilFighter = new EvilFighterBuilder().Build();
        IEntity mimikChest = new MimikChestBuilder().Build();
        var table1 = new PlayerTable();
        var table2 = new PlayerTable();
        BattleFacade battle = BattleFacade.Create;

        // Act
        table1.AddEntity(evilFighter);
        table2.AddEntity(mimikChest);
        BattleResult winner = battle.PlayersBattle(table1, table2);

        // Arrange
        var winnerTable = (BattleResult.Win)winner;

        // Assert
        Assert.IsType<BattleResult.Win>(winner);
        Assert.Equal(table1, winnerTable.Table);
    }

    [Fact]
    public void Should_ImmortalHorrorWinCombatAnalyst_Success()
    {
        // Arrange
        IEntity combatAnalyst = new CombatAnalystBuilder().Build();
        IEntity immortalHorror = new ImmortalHorrorBuilder().Build();
        var table1 = new PlayerTable();
        var table2 = new PlayerTable();
        BattleFacade battle = BattleFacade.Create;

        // Act
        table1.AddEntity(combatAnalyst);
        table2.AddEntity(immortalHorror);
        BattleResult winner = battle.PlayersBattle(table1, table2);

        // Arrange
        var winnerTable = (BattleResult.Win)winner;

        // Assert
        Assert.IsType<BattleResult.Win>(winner);
        Assert.Equal(table2, winnerTable.Table);
    }
}
