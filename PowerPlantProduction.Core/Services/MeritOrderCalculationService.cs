using PowerPlantProduction.Core.Models;
using PowerPlantProduction.Core.Strategies;

namespace PowerPlantProduction.Core.Services
{

    public class MeritOrderCalculationService: IMeritOrderCalculationService
    {

        public IMeritOrderStrategy _strategy;

        public async Task<List<PowerplantProduction>> GenerateProductionPlan(Payload payload, CancellationToken cancellationToken)
        {
            if (payload.Fuels.WindPercentage > 50)
            {
                _strategy = new HighWindStrategy(payload);
            }
            else if (payload.Fuels.GasEuroMWh < 20)
            {
                _strategy = new LowCostFuelStrategy(payload);
            }
            else
            {
                _strategy = new HighDemandStrategy(payload);
            }

            return _strategy.CalculateMeritOrder();
        }

    }
}
