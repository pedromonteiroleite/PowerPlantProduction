using PowerPlantProduction.Core.Models;

namespace PowerPlantProduction.Core.Strategies
{
    public class LowCostFuelStrategy : MeritOrderStrategy, IMeritOrderStrategy
    {

        public LowCostFuelStrategy(Payload payload)
        {
            Payload = payload;
        }

        public List<PowerplantProduction> CalculateMeritOrder()
        {
            AddPowerPlantLoad(Payload.Load);
            return PowerplantPlanProductionPlan;
        }
        public override Powerplant GetPowerplant()
        {
            // Naive implementation.
            return GasPlants?.FirstOrDefault() ?? TurboPlants?.FirstOrDefault() ?? WindPlants?.FirstOrDefault() ?? throw new Exception("No plants left.");
        }
    }
}
