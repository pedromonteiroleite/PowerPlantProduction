using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Powerplant
{
    public string Name { get; set; }
    public string Type { get; set; }
    public double Efficiency { get; set; }
    public double Pmin { get; set; }
    public double Pmax { get; set; }
}