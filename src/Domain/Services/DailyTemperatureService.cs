using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services;

public class DailyTemperatureService
{

    public List<RecordedDailyTemperature> GenerateTemperatureRecs()
    {
        var unit = TemperatureUnit.Celcius;
        var result = new List<RecordedDailyTemperature>()
            {
                new RecordedDailyTemperature(57, 30, unit),
                new RecordedDailyTemperature(60, 35, unit),
                new RecordedDailyTemperature(60, 35, unit),
                new RecordedDailyTemperature(60, 35, unit),
                new RecordedDailyTemperature(60, 35, unit),
                new RecordedDailyTemperature(63, 33, unit),
            };

        return result;
    }

    public List<DailyTemperature> GenerateTemperature()
    {
        var result = new List<DailyTemperature>()
            {
                new DailyTemperature(57, 30),
                new DailyTemperature(60, 35),
                new DailyTemperature(60, 35),
                new DailyTemperature(60, 35),
                new DailyTemperature(60, 35),
                new DailyTemperature(63, 33),
            };

        return result;

    }
}
