//using Microsoft.AspNetCore.Mvc;
//using PowerPlantProduction.API.Commands;
//using PowerPlantProduction.Core.Models; 

//namespace PowerPlantProductionAPI.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class ProductionPlanController : ControllerBase
//    {

//        private readonly IProductionPlanCommand _productionPlanCommand;

//        public ProductionPlanController(IProductionPlanCommand productionPlanCommand)
//        {
//            _productionPlanCommand = productionPlanCommand;
//        }

//        [HttpPost]
//        public async Task<ActionResult<List<PowerplantProduction>>> Post([FromBody] Payload payload, CancellationToken cancellationToken)
//        {
//            List<PowerplantProduction> productionPlan = await _productionPlanCommand.GenerateProductionPlan(payload, cancellationToken);

//            return Ok(productionPlan);
//        }

//    }
//}
