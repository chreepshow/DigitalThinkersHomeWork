namespace DigitalThinkersHomeWork.Driver
{
    public interface IDriverService
    {
        public Task<List<DriverModel>> GetAllDrivers();
        public Task<List<DriverModel>> OvertakeByOne(int id);
    }
}
