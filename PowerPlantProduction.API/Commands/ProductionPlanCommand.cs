using PowerPlantProduction.Core.Models;
using PowerPlantProduction.Core.Services;

namespace PowerPlantProduction.API.Commands
{
    public class ProductionPlanCommand : IProductionPlanCommand
    {

        IMeritOrderCalculationService _meritOrderCalculationService;

        public ProductionPlanCommand(IMeritOrderCalculationService meritOrderCalculationService)
        {
            _meritOrderCalculationService = meritOrderCalculationService;
        }

        public async Task<List<PowerplantProduction>> GenerateProductionPlan(Payload payload, CancellationToken cancellationToken)
        {

            return await _meritOrderCalculationService.GenerateProductionPlan(payload, cancellationToken);

        }

    }
}
