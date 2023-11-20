using PowerPlantProduction.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlantProduction.Core.Strategies
{
    public interface IMeritOrderStrategy
    {
        List<PowerplantProduction> CalculateMeritOrder();
    }
}
