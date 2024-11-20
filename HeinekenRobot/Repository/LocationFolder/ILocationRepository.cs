using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.LocationFolder
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<bool> AddLocation(Location location);
        Task<Location?> GetLocationByIdAsync(int locationId);

        Task updateLocation(Location location);
        Task<bool> IsLocationOperated(int locationId);
        Task DeleteLocation(int locationId);

    }
}
