using Domain.ValueObjects;

namespace Domain.Entities;

public readonly record struct RecordedDailyTemperature(double HighTemp, double LowTemp, TemperatureUnit Unit)
{
    public double Mean => (HighTemp + LowTemp) / 2.0;
}