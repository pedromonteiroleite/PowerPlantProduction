using Domain.Entities;

namespace Application.MeritOrder.Queries.GetProductionPlan.Strategies;

public interface IMeritOrderStrategy
{
    List<PowerplantProduction> CalculateMeritOrder();
}
