using DigitalThinkersHomeWork.Driver;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThinkersHomeWork.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private ILogger<DriversController> Logger { get; }
        private IDriverService DriverService { get; }

        public DriversController(ILogger<DriversController> logger, IDriverService driverService)
        {
            Logger = logger;
            DriverService = driverService;
        }

        [HttpGet]
        public async Task<IEnumerable<DriverModel>> GetAllDrivers()
        {
            Logger.LogInformation("Get all drivers endpoint called.");
            return await DriverService.GetAllDrivers();
        }

        [HttpPost("{id}/overtake")]
        public async Task<IEnumerable<DriverModel>> DriverOvertakeByOne(int id)
        {
            Logger.LogInformation("DriverOvertakeByOne endpoint called.");
            return await DriverService.OvertakeByOne(id);
        }
    }
}