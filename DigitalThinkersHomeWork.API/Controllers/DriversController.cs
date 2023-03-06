using Microsoft.AspNetCore.Mvc;

namespace DigitalThinkersHomeWork.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private ILogger<DriversController> Logger { get; }
        private static readonly string[] Drivers = new[]
        {
            "Driver1", "Driver2", "Driver3", "Driver4",
        };


        public DriversController(ILogger<DriversController> logger)
        {
            Logger = logger;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            Logger.LogInformation("Get method called.");
            return Drivers.AsEnumerable();
        }
    }
}