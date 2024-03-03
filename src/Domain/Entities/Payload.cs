namespace Domain.Entities;
public class Payload
{
    public double Load { get; set; }
    public Fuel Fuels { get; set; }
    public List<Powerplant> Powerplants { get; set; }
}