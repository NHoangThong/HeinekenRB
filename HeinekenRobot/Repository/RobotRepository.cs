using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository
{
    public class RobotRepository : IRobotRepository
    {
        private readonly HeniekenDbContext _context;

        public RobotRepository(HeniekenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Robot>> GetAll()
        {
            return await _context.Robots.ToListAsync();
        }
        public async Task<Robot> GetRobotById(int id)
        {
            return await _context.Robots.Include(r => r.Location).Include(r => r.RobotType).FirstOrDefaultAsync(r => r.RobotId == id);

        }
        public async Task AddRobot(Robot robot)
        {
            await _context.Robots.AddAsync(robot);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRobot(Robot robot)
        {
            _context.Robots.Update(robot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRobot(int id)
        {
            var robot = await _context.Robots.FindAsync(id);
            if (robot != null)
            {
                _context.Robots.Remove(robot);
                await _context.SaveChangesAsync();
            }
        }
    }
}
