using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository.RewardRuleFolder
{
    public class RewardRuleRepository:IRewardRuleRepository
    {
        private readonly HeniekenDbContext _context;

        public RewardRuleRepository(HeniekenDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<object>> GetRewardRulesWithDetails()
        {
            return await _context.RewardRules
                .Include(r => r.Campaign)
                .Include(r => r.Gift)
                .Select(r => new
                {
                    r.RuleId,
                    CampaignName = r.Campaign!.Name,
                    r.PointRangeMin,
                    r.PointRangeMax,
                    r.GiftChance,
                    GiftName = r.Gift!.Name,
                    LocationsApplied = _context.Locations
                        .Count(l => l.CampaignRobotMachines.Any(c => c.CampaignId == r.CampaignId)),
                    r.CreatedDate
                })
                .ToListAsync();
        }

        public async Task AddRewardRule(RewardRule rewardRule)
        {
            await _context.RewardRules.AddAsync(rewardRule);
            await _context.SaveChangesAsync();
        }

        public async Task<RewardRule?> GetRewardRuleById(int ruleId)
        {
            return await _context.RewardRules
                .Include(r => r.Gift) // Lấy thông tin quà tặng
                .Include(r => r.Campaign) // Lấy thông tin chiến dịch
                .FirstOrDefaultAsync(r => r.RuleId == ruleId);
        }

        public async Task UpdateRewardRule(RewardRule rewardRule)
        {
            _context.RewardRules.Update(rewardRule);
            await _context.SaveChangesAsync();
        }

    }
}
