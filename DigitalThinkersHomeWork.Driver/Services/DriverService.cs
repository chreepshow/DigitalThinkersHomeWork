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

        public async Task<ICollection<DriverModel>> GetAllDrivers()
        {
            Logger.LogInformation("Query all drivers through database");
            return await Task.Run(() => DbContext.GetAllDrivers());
        }
    }
}
