using Microsoft.AspNetCore.Mvc;

namespace PowerPlantProductionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {

        private readonly ILogger<ExceptionController> _logger;

        public ExceptionController(ILogger<ExceptionController> logger)
        {

            _logger = logger;

        }

        [HttpGet]
        public void Get()
        {
            _logger.LogWarning(nameof(ExceptionController));
            throw new NotImplementedException();
        }

    }
}
