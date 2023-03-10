using DigitalThinkersHomeWork.Driver;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DigitalThinkersHomeWork.Infrastructure
{
    public class DriverDbContext : IDriverDbContext
    {
        private List<int> places = new List<int>();
        private ILogger<DriverDbContext> Logger { get; }
        private List<DriverModel> Drivers { get; set; } = new List<DriverModel>();

        public DriverDbContext(ILogger<DriverDbContext> logger)
        {
            Logger = logger;
            Logger.LogInformation("Initialise and seed database");
            ReadDrivers();
            SetRandomPlacesToDrivers();
            Logger.LogInformation("Initialise and seed finished");
        }

        public List<DriverModel> GetAllDrivers()
        {
            Logger.LogInformation("Read all drivers from database");
            return Drivers.ConvertAll(driver => new DriverModel
            {
               Code= driver.Code,
               Country= driver.Country,
               FirstName= driver.FirstName,
               Id= driver.Id,
               ImageUrl= driver.ImageUrl,
               LastName= driver.LastName,
               Place= driver.Place,
               Team= driver.Team,
            });
        }

        public void UpdateAllDrivers(List<DriverModel> drivers)
        {
            Logger.LogInformation("Update all drivers in database");
            Drivers.Clear();
            Drivers = drivers;
            Logger.LogInformation("Update all drivers in database finished");
        }

        private void ReadDrivers()
        {
            string fileName = "./seed/drivers.json";
            string jsonString = File.ReadAllText(fileName);
            Drivers = JsonSerializer.Deserialize<List<DriverModel>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            foreach (var driver in Drivers)
            {
                driver.ImageUrl = $"/images/{driver.Code.ToLower()}.png";
            }
        }

        private void SetRandomPlacesToDrivers()
        {
            for (int i = 0; i < Drivers.Count; ++i)
            {
                places.Add(i + 1);
            }

            var random = new Random();
            int driverIndex = 0;
            while(places.Count > 0)
            {
                var placeIndex = random.Next(places.Count);
                var currentPlace = places.ElementAt(placeIndex);

                Drivers.ElementAt(driverIndex++).Place = currentPlace;
                places.Remove(currentPlace);
            }
        }
    }
}
