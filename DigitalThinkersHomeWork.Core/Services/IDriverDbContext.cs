using DigitalThinkersHomeWork.Driver;

namespace DigitalThinkersHomeWork.Infrastructure
{
    public interface IDriverDbContext
    {
        public List<DriverModel> GetAllDrivers();
        public void UpdateAllDrivers(List<DriverModel> drivers);
    }
}
