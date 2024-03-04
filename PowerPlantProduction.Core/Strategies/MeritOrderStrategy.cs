using PowerPlantProduction.Core.Models;

namespace PowerPlantProduction.Core.Strategies
{
    public abstract class MeritOrderStrategy
    {

        public List<Powerplant> WindPlants
        {
            get => Payload.Powerplants.Where(x => x.Type == "windturbine" && !TickedPlants.Contains(x.Name)).Select(x => x).OrderByDescending(x => x.Efficiency).ThenBy(x => x.Pmax).ToList();
        }

        public List<Powerplant> GasPlants
        {
            get => Payload.Powerplants.Where(x => x.Type == "gasfired" && !TickedPlants.Contains(x.Name)).Select(x => x).OrderByDescending(x => x.Efficiency).ThenBy(x => x.Pmax).ToList();
        }

        public List<Powerplant> TurboPlants
        {
            get => Payload.Powerplants.Where(x => x.Type == "turbojet" && !TickedPlants.Contains(x.Name)).Select(x => x).OrderByDescending(x => x.Efficiency).ThenBy(x => x.Pmax).ToList();
        }

        public List<string> TickedPlants { get; set; } = new List<string>();

        public List<PowerplantProduction> PowerplantPlanProductionPlan { get; set; } = new();

        public double TotalAssignedLoad { get; set; } = 0;

        public abstract Powerplant GetPowerplant(); // Where the knowledge from the PO and Stakeholders will dictate the best MeritOrder Algho to implement for the strategy.

        public void AddPowerPlantLoad(double needed)
        {
            if (TotalAssignedLoad >= Payload.Load)
                return;
            var powerplant = GetPowerplant();
            var powerplantProduction = new PowerplantProduction
            {
                Name = powerplant.Name
            };

            if (powerplant.Pmin > 0 && needed < powerplant.Pmin)
            {
                TickedPlants.Add(powerplant.Name);
            }
            if (powerplant.Pmin > needed)
            {
                TickedPlants.Add(powerplant.Name);
            }
            else
            {
                if (needed >= powerplant.Pmax)
                {
                    TickedPlants.Add(powerplant.Name);
                    powerplantProduction.P = powerplant.Pmax;
                }
                else
                {
                    TickedPlants.Add(powerplant.Name);
                    powerplantProduction.P = needed;
                }
                TotalAssignedLoad += powerplantProduction.P;
                PowerplantPlanProductionPlan.Add(powerplantProduction);
            }
            AddPowerPlantLoad(Payload.Load - TotalAssignedLoad);

        }

        public Payload Payload = new();

    }
}
