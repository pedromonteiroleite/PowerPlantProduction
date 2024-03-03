namespace Domain.ValueObjects;

public class TemperatureUnit
{
    public string? Name { get; }
    public string? Symbol { get; }

    public TemperatureUnit() {}

    protected TemperatureUnit(string name, string symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public static TemperatureUnit Celcius => new("Celcius", "°C");
    public static TemperatureUnit Fahrenheit => new("Fahrenheit", "°F");
    public static TemperatureUnit Kelvin => new("Kelvin", "K");

    public static IEnumerable<TemperatureUnit> SupportedColours
    {
        get
        {
            yield return Celcius;
            yield return Fahrenheit;
            yield return Kelvin;
        }
    }

}
