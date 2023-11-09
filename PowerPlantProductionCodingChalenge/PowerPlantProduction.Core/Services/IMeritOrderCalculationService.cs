using PowerPlantProduction.Core.Models;

namespace PowerPlantProduction.Core.Services
{
    public interface IMeritOrderCalculationService
    {
        public Task<List<PowerplantProduction>> GenerateProductionPlan(Payload payload, CancellationToken cancellationToken);
    }
}
