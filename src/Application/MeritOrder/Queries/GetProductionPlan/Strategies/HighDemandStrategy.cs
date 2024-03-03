using Domain.Entities;

namespace Application.MeritOrder.Queries.GetProductionPlan.Strategies;

public class HighDemandStrategy : MeritOrderStrategy, IMeritOrderStrategy
{

    public HighDemandStrategy(Payload payload)
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
