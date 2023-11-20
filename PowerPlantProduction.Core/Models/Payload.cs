using System.Text.Json.Serialization;

namespace PowerPlantProduction.Core.Models
{
    public class Payload
    {
        public double Load { get; set; }
        public Fuel Fuels { get; set; }
        public List<Powerplant> Powerplants { get; set; }
    }

    public class Fuel
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public double GasEuroMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double KerosineEuroMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public double Co2EuroTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public double WindPercentage { get; set; }
    }

    public class Powerplant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Efficiency { get; set; }
        public double Pmin { get; set; }
        public double Pmax { get; set; }
    }

}
