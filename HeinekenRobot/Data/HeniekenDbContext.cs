using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Data
{
    public class HeniekenDbContext: DbContext
    {
        public HeniekenDbContext(DbContextOptions<HeniekenDbContext> context): base(context) { }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Robot> Robots { get; set; }
    }
}
