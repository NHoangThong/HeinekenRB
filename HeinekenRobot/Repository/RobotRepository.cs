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
    }
}
