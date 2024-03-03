namespace Domain.Entities;
public class DailyTemperature
{
    public double HighTemp { get; set; }
    public double LowTemp { get; set; }
    public DailyTemperature(double HighTemp, double LowTemp)
    {
        this.HighTemp = HighTemp;
        this.LowTemp = LowTemp;
    }
}