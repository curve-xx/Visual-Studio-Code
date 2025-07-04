using System;

namespace GameLibrary.UnitTests;

public class TreasureChestTests
{
    [Fact]
    public void CanOpenTest()
    {
        //Arrange
        var chest = new TreasureChest(true);

        //Act
        var result = chest.CanOpen(true);

        //Assert
        Assert.True(result);
    }

}
