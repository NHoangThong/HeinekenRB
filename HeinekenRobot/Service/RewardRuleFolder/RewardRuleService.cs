using HeinekenRobot.Models;
using HeinekenRobot.Repository.GiftFolder;
using HeinekenRobot.Repository.RewardRuleFolder;

namespace HeinekenRobot.Service.RewardRuleFolder
{
    public class RewardRuleService:IRewardRuleService
    {
        private readonly IRewardRuleRepository _repository;
        private readonly IGiftRepository _giftRepository;

        public RewardRuleService(IRewardRuleRepository repository, IGiftRepository giftRepository)
        {
            _repository = repository;
            _giftRepository = giftRepository;
        }
        public async Task<IEnumerable<object>> GetRewardRules()
        {
            return await _repository.GetRewardRulesWithDetails();

        }

        public async Task AddRewardRule(RewardRule rewardRule)
        {
            // Kiểm tra dữ liệu nhập
            if (rewardRule.PointRangeMin < 0 || rewardRule.PointRangeMax <= rewardRule.PointRangeMin)
            {
                throw new ArgumentException("Invalid point range.");
            }

            if (rewardRule.GiftChance < 0 || rewardRule.GiftChance > 100)
            {
                throw new ArgumentException("Gift chance must be between 0 and 100.");
            }

            // Thêm quy tắc trúng thưởng vào database
            await _repository.AddRewardRule(rewardRule);
        }

        public async Task<RewardRule?> GetRewardRuleDetails(int ruleId)
        {
            return await _repository.GetRewardRuleById(ruleId);
        }

        public async Task UpdateRewardRule(RewardRule updatedRule)
        {
            var existingRule = await _repository.GetRewardRuleById(updatedRule.RuleId);

            if (existingRule == null)
            {
                throw new KeyNotFoundException("Reward rule not found.");
            }

            // Cập nhật thông tin cơ bản
            existingRule.PointRangeMin = updatedRule.PointRangeMin;
            existingRule.PointRangeMax = updatedRule.PointRangeMax;

            // Nếu quà tặng đã tồn tại, cập nhật GiftChance
            if (existingRule.GiftId == updatedRule.GiftId)
            {
                existingRule.GiftChance = updatedRule.GiftChance;
            }
            else
            {
                // Thêm mới quà tặng, mặc định số lượng = 0
                var gift = await _giftRepository.GetGiftById(updatedRule.GiftId);
                if (gift == null)
                {
                    throw new KeyNotFoundException("Gift not found.");
                }

                gift.TotalCount = 0; // Đặt số lượng mặc định là 0
                existingRule.GiftId = updatedRule.GiftId;
                existingRule.GiftChance = updatedRule.GiftChance;
            }

            // Cập nhật quy tắc
            await _repository.UpdateRewardRule(existingRule);
        }

        public async Task DeleteRewardRule(int ruleId)
        {
            // Lấy thông tin quy tắc
            var rewardRule = await _repository.GetRewardRuleById(ruleId);
            if (rewardRule == null)
            {
                throw new KeyNotFoundException("Reward rule not found.");
            }

            // Kiểm tra nếu quy tắc đang được sử dụng
            if (await _repository.IsRuleUsedInCampaign(rewardRule.CampaignId))
            {
                throw new InvalidOperationException("Cannot delete reward rule because it is used in a campaign.");
            }

            // Xóa quy tắc
            await _repository.DeleteRewardRule(rewardRule);
        }
    }   
}
