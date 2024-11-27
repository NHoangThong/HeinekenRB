using HeinekenRobot.Models;

namespace HeinekenRobot.Service.RewardRuleFolder
{
    public interface IRewardRuleService
    {
        Task<IEnumerable<object>> GetRewardRules();
        Task AddRewardRule(RewardRule rewardRule);
        Task<RewardRule?> GetRewardRuleDetails(int ruleId);
        Task UpdateRewardRule(RewardRule updatedRule);
        Task DeleteRewardRule(int ruleId);
    }
}
