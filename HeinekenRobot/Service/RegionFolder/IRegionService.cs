using HeinekenRobot.Models;

namespace HeinekenRobot.Service.RegionFolder
{
    public interface IRegionService
    {
        Task<IEnumerable<object>> GetAllRegionsWithLocationCount();
        Task AddRegion(Region region);
        Task<Region?> GetRegionById(int regionId);
        Task UpdateRegion(Region updatedRegion);
        Task<bool> DeleteRegion(int regionId);

    }
}
