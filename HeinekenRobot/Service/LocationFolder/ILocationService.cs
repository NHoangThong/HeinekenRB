using HeinekenRobot.Models;

namespace HeinekenRobot.Service.LocationFolder
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<bool> AddLocation(Location location);
        Task<object?> GetLocationDetailsAsync(int locationId);
        Task updateLocation(Location location);
        Task DeleteLocation(int locationId);
    }
}
