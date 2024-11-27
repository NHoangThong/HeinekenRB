using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.RegionFolder
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegions();
        Task<Region?> GetRegionByName(string regionName);
        Task<bool> CheckProvinceExists(string province);
        Task AddRegion(Region region);
        Task<Region?> GetRegionById(int regionId);
        Task UpdateRegion(Region region);
        Task<bool> IsRegionInUse(int regionId);
        Task DeleteRegion(int regionId);
    }
}
