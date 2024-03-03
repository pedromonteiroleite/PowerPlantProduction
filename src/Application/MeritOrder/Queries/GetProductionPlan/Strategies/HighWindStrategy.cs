using Domain.Entities;

namespace Application.MeritOrder.Queries.GetProductionPlan.Strategies;

public class HighWindStrategy : MeritOrderStrategy, IMeritOrderStrategy
{

    public HighWindStrategy(Payload payload)
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
        return WindPlants?.FirstOrDefault() ?? GasPlants?.FirstOrDefault() ?? TurboPlants?.FirstOrDefault() ?? throw new Exception("No plants left.");
    }

}
