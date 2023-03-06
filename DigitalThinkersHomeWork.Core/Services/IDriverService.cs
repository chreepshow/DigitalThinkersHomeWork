namespace DigitalThinkersHomeWork.Driver
{
    public interface IDriverService
    {
        public Task<ICollection<DriverModel>> GetAllDrivers();
    }
}
