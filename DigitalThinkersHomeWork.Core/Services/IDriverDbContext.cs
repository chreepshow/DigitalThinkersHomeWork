using DigitalThinkersHomeWork.Driver;

namespace DigitalThinkersHomeWork.Infrastructure
{
    public interface IDriverDbContext
    {
        public ICollection<DriverModel> GetAllDrivers();
        public void UpdateAllDrivers(ICollection<DriverModel> drivers);
    }
}
