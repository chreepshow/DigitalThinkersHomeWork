using DigitalThinkersHomeWork.Infrastructure;
using Microsoft.Extensions.Logging;


namespace DigitalThinkersHomeWork.Driver
{
    internal class DriverService : IDriverService
    {
        private ILogger<DriverService> Logger { get; }
        public IDriverDbContext DbContext { get; }

        public DriverService(ILogger<DriverService> logger, IDriverDbContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public async Task<List<DriverModel>> GetAllDrivers()
        {
            Logger.LogInformation("Query all drivers through database");
            return await Task.Run(() => DbContext.GetAllDrivers());
        }

        public async Task<List<DriverModel>> OvertakeByOne(int id)
        {
            Logger.LogInformation($"#{id} driver started overtaking");
            return await Task.Run(() =>
            {
                var drivers = DbContext.GetAllDrivers();

                var overtakingDriver = drivers.Single(d => d.Id == id);
                if (overtakingDriver.Place == 1)
                    return drivers;

                var overtakenDriver = drivers.Single(d => d.Place == overtakingDriver.Place - 1);
                var tmpPlace = overtakenDriver.Place;

                overtakenDriver.Place = overtakingDriver.Place;
                overtakingDriver.Place = tmpPlace;

                DbContext.UpdateAllDrivers(drivers);
                Logger.LogInformation($"#{id} finished overtaking");
                return drivers;
            });
        }
    }
}
