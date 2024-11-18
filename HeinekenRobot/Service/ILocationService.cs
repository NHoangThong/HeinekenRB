using HeinekenRobot.Models;

namespace HeinekenRobot.Service
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<bool> AddLocation(Location location);
        Task<object?> GetLocationDetailsAsync(int locationId);
    }
}
