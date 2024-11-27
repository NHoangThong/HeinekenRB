using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository.RegionFolder
{
    public class RegionRepository:IRegionRepository
    {
        private readonly HeniekenDbContext _context;

        public RegionRepository(HeniekenDbContext context) { 
            _context= context;
        
        }
        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await _context.Regions.Include(r => r.Locations).ToListAsync();
        }
        public async Task<Region?> GetRegionByName(string regionName)
        {
            return await _context.Regions.FirstOrDefaultAsync(r => r.RegionName == regionName);
        }

        public async Task<bool> CheckProvinceExists(string province)
        {
            return await _context.Regions.AnyAsync(r => r.Province == province);
        }

        public async Task AddRegion(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
        }

        public async Task<Region?> GetRegionById(int regionId)
        {
            return await _context.Regions
                .Include(r => r.Locations) // Bao gồm danh sách địa điểm liên kết
                .FirstOrDefaultAsync(r => r.RegionId == regionId);
        }
        public async Task UpdateRegion(Region region)
        {
            _context.Regions.Update(region);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsRegionInUse(int regionId)
        {
            // Kiểm tra xem có địa điểm nào thuộc khu vực này không
            return await _context.Locations.AnyAsync(l => l.RegionId == regionId);
        }

        public async Task DeleteRegion(int regionId)
        {
            var region = await GetRegionById(regionId);
            if (region != null)
            {
                _context.Regions.Remove(region);
                await _context.SaveChangesAsync();
            }
        }
    }
}
