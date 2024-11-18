using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository
{
    public class LocationRepository:ILocationRepository
    {
        private readonly HeniekenDbContext _context;

        public LocationRepository(HeniekenDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _context.Locations.Include(m=>m.Region).Include(m=>m.Robots).Include(m=>m.RecycleMachines).ToListAsync();

        }
        public async Task<bool> AddLocation(Location location)
        {
            var check = await _context.Locations.AnyAsync(l => l.Name == location.Name);
            if (check)
            {
                throw new Exception("The location name already exists, please choose another name.");
            }
            // Thêm địa điểm vào DB
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Location?> GetLocationByIdAsync(int locationId)
        {
            return await _context.Locations
                .Include(l => l.Region)
                .Include(l => l.Robots)
                .Include(l => l.RecycleMachines)
                .FirstOrDefaultAsync(l => l.LocationId == locationId);
        }
    }
}
