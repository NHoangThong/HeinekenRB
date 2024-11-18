using HeinekenRobot.Models;

namespace HeinekenRobot.Repository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<bool> AddLocation(Location location);
        Task<Location?> GetLocationByIdAsync(int locationId);

    }
}
