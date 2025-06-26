using System;

namespace MyLibrary;

public static class WeatherCalculator
{
    public static string DetermineSeason(DateOnly date)
    {
        return date.Month switch
        {
            >= 3 and <= 5 => "Spring",
            >= 6 and <= 8 => "Summer",
            >= 9 and <= 11 => "Autumn",
            _ => "Winter"
        };
    }
}
