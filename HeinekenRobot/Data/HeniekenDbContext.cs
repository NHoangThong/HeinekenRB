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
        public DbSet<RecycleMachine> RecycleMachines { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignRobotMachine> CampaignRobotMachines { get; set; }
        public DbSet<RewardRule> RewardRules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GiftRedemption> GiftRedemptions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CampaignRobotMachine
            modelBuilder.Entity<CampaignRobotMachine>()
                .HasOne(crm => crm.Campaign)
                .WithMany(c => c.CampaignRobotMachines)
                .HasForeignKey(crm => crm.CampaignId)
                .OnDelete(DeleteBehavior.Cascade); // Chỉ đặt Cascade nếu thực sự cần

            // Sử dụng DeleteBehavior.Restrict cho các khóa ngoại khác để tránh xung đột
            modelBuilder.Entity<CampaignRobotMachine>()
                .HasOne(crm => crm.Location)
                .WithMany(l => l.CampaignRobotMachines)
                .HasForeignKey(crm => crm.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CampaignRobotMachine>()
                .HasOne(crm => crm.Machine)
                .WithMany(m => m.CampaignRobotMachines)
                .HasForeignKey(crm => crm.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CampaignRobotMachine>()
                .HasOne(crm => crm.Robot)
                .WithMany(r => r.CampaignRobotMachines)
                .HasForeignKey(crm => crm.RobotId)
                .OnDelete(DeleteBehavior.Restrict);


            //Transaction
            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Campaign)
               .WithMany()
               .HasForeignKey(t => t.CampaignId)
               .OnDelete(DeleteBehavior.Restrict); // Thay đổi từ Cascade thành Restrict

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Gift)
                .WithMany()
                .HasForeignKey(t => t.GiftId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Location)
                .WithMany()
                .HasForeignKey(t => t.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Machine)
                .WithMany()
                .HasForeignKey(t => t.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Robot)
                .WithMany()
                .HasForeignKey(t => t.RobotId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
