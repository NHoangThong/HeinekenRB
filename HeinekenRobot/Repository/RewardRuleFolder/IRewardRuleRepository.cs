using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.RewardRuleFolder
{
    public interface IRewardRuleRepository
    {
        Task<IEnumerable<object>> GetRewardRulesWithDetails();
        Task AddRewardRule(RewardRule rewardRule);
        Task<RewardRule?> GetRewardRuleById(int ruleId);
        Task UpdateRewardRule(RewardRule rewardRule);
        Task<bool> IsRuleUsedInCampaign(int campaignId);
        Task DeleteRewardRule(RewardRule rewardRule);
    }
}
