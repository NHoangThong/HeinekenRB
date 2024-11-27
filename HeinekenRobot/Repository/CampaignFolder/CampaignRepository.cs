using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository.CampaignFolder
{
    public class CampaignRepository:ICampaignRepository
    {
        private readonly HeniekenDbContext _context;

        public CampaignRepository(HeniekenDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Campaign>> GetActiveCampaigns()
        {
            // Lấy danh sách chiến dịch có trạng thái Active
            return await _context.Campaigns
                .Where(c => c.Status == "Active" )
                .Include(c => c.Region) // Bao gồm thông tin khu vực
                .Include(c => c.CampaignRobotMachines) // Bao gồm các thiết bị được phân bổ
                .ToListAsync();
        }
        public async Task AddCampaign(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
        }
        public async Task<Campaign> GetCampaignDetails(int campaignId)
        {
            return await _context.Campaigns
                .Include(c => c.Region)
                .Include(c => c.CampaignRobotMachines)
                .ThenInclude(crm => crm.Machine)
                .Include(c => c.CampaignRobotMachines)
                .ThenInclude(crm => crm.Robot)
                .Include(c => c.RewardRules)
                .ThenInclude(rr => rr.Gift)
                .FirstOrDefaultAsync(c => c.CampaignId == campaignId);
        }
        public async Task UpdateCampaign(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCampaign(Campaign campaign)
        {
            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
        }
    }
}
