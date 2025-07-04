using System;

namespace GameLibrary.UnitTests;

public class TreasureChestTests
{
    // MethodName_StateUnderTest_ExpectedBehavior

    [Fact]
    public void CanOpen_ChestIsLockedAndHasKey_ReturnsTrue()
    {
        // Arrange
        var sut = new TreasureChest(true);

        // Act
        var result = sut.CanOpen(true);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanOpen_ChestIsLockedAndNoKey_ReturnsFalse()
    {
        // Arrange
        var sut = new TreasureChest(true);

        // Act
        var result = sut.CanOpen(false);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanOpen_ChestIsUnlockedAndHasKey_ReturnsTrue()
    {
        // Arrange
        var sut = new TreasureChest(false);

        // Act
        var result = sut.CanOpen(true);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void CanOpen_ChestIsUnlockedAndNoKey_ReturnsTrue()
    {
        // Arrange
        var sut = new TreasureChest(false);

        // Act
        var result = sut.CanOpen(false);

        // Assert
        Assert.True(result);
    }

}
