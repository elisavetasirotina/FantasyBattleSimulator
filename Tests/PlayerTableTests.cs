using Entities;
using Table;
using UseCases;
using NSubstitute;
using Xunit;

namespace Tests;

public class PlayerTableTests
{
    [Fact]
    public void Should_AddMoreSevenEntities_Failure()
    {
        // Arrange
        var table = new PlayerTable();
        IEntity mockEntity = Substitute.For<IEntity>();
        for (int i = 0; i < 7; i++)
        {
            // Act
            TableResult result = table.AddEntity(mockEntity);

            // Assert
            Assert.IsType<TableResult.Success>(result);
        }

        // Act
        TableResult resultFailure = table.AddEntity(mockEntity);

        // Assert
        Assert.IsType<TableResult.EntitiesLimitError>(resultFailure);
    }
}