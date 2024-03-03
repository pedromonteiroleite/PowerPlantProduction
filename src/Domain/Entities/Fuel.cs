using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities;

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
