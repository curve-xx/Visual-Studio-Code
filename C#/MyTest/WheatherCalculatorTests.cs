using System;
using MyLibrary;

namespace MyTest;

public class WheatherCalculatorTests
{
    [Theory]
    [InlineData(2024, 3, 1, "Spring")]
    [InlineData(2024, 4, 15, "Spring")]
    [InlineData(2024, 5, 31, "Spring")]
    [InlineData(2024, 6, 1, "Summer")]
    [InlineData(2024, 7, 15, "Summer")]
    [InlineData(2024, 8, 31, "Summer")]
    [InlineData(2024, 9, 1, "Autumn")]
    [InlineData(2024, 10, 15, "Autumn")]
    [InlineData(2024, 11, 30, "Autumn")]
    [InlineData(2024, 12, 1, "Winter")]
    [InlineData(2024, 1, 15, "Winter")]
    [InlineData(2024, 2, 28, "Winter")]
    public void DetermineSeason_ReturnsExpectedSeason(int year, int month, int day, string expected)
    {
        var date = new DateOnly(year, month, day);
        var result = WeatherCalculator.DetermineSeason(date);
        Assert.Equal(expected, result);
    }
}
