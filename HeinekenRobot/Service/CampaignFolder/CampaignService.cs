using HeinekenRobot.Models;
using HeinekenRobot.Repository.CampaignFolder;
using HeinekenRobot.Repository.RecycleMachineFolder;
using HeinekenRobot.Repository.RewardRuleFolder;

namespace HeinekenRobot.Service.CampaignFolder
{
    public class CampaignService:ICampaignService
    {
        private readonly ICampaignRepository _repository;
       
        public CampaignService(ICampaignRepository repository)
        {
            _repository = repository;
            
        }
        public async Task<IEnumerable<object>> GetActiveCampaignSummaries()
        {
            var campaigns = await _repository.GetActiveCampaigns();

            return campaigns.Select(c => new
            {
                CampaignId = c.CampaignId,
                Name = c.Name,
                Description = c.Description,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Status = c.Status,
                RegionName = c.Region?.RegionName ?? "Unknown", // Lấy tên vùng nếu có
                DeviceCount = c.CampaignRobotMachines.Count // Số lượng thiết bị
            }).ToList();
        }
        public async Task AddCampaign(Campaign campaign)
        {
            // Kiểm tra dữ liệu cơ bản nếu cần
            if (campaign.StartDate >= campaign.EndDate)
            {
                throw new ArgumentException("EndDate must be later than StartDate.");
            }

            // Thêm chiến dịch vào cơ sở dữ liệu
            await _repository.AddCampaign(campaign);
        }
        public async Task<object> GetCampaignDetails(int campaignId)
        {
            var campaign = await _repository.GetCampaignDetails(campaignId);
            if (campaign == null)
            {
                throw new KeyNotFoundException("Campaign not found.");
            }

            return new
            {
                campaign.CampaignId,
                campaign.Name,
                campaign.Description,
                campaign.StartDate,
                campaign.EndDate,
                campaign.Status,
                RegionName = campaign.Region?.RegionName ?? "Unknown",
                RewardRules = campaign.RewardRules.Select(rr => new
                {
                    rr.RuleId,
                    rr.PointRangeMin,
                    rr.PointRangeMax,
                    rr.GiftId,
                    GiftName = rr.Gift?.Name ?? "Unknown",
                    rr.GiftChance
                }),
                Gifts = campaign.RewardRules.Select(rr => rr.Gift).Distinct().Select(g => new
                {
                    g.GiftId,
                    g.Name,
                    g.TotalCount,
                    g.RedeemedCount,
                    g.ExpiredCount,
                    RemainingCount = g.TotalCount - g.RedeemedCount - g.ExpiredCount
                }),
                GiftRedemptionHistory = campaign.CampaignRobotMachines.SelectMany(crm => crm.Machine.GiftRedemptions).Select(gr => new
                {
                    gr.RedemptionDate,
                    PGStaff = gr.User?.FullName ?? "Unknown"
                })
            };
        }
        public async Task UpdateCampaign(int campaignId, Campaign updatedCampaign)
        {
            // 1. Kiểm tra xem campaign có tồn tại không
            var existingCampaign = await _repository.GetCampaignDetails(campaignId);
            if (existingCampaign == null)
            {
                throw new ArgumentException($"Campaign with ID {campaignId} does not exist.");
            }

            // 2. Cập nhật thông tin chiến dịch
            existingCampaign.Name = updatedCampaign.Name;
            existingCampaign.Description = updatedCampaign.Description;
            existingCampaign.StartDate = updatedCampaign.StartDate;
            existingCampaign.EndDate = updatedCampaign.EndDate;
            existingCampaign.Status = updatedCampaign.Status;
            existingCampaign.RegionId = updatedCampaign.RegionId;

            // 3. Ghi lại thay đổi
            await _repository.UpdateCampaign(existingCampaign);
        }
        public async Task DeleteCampaign(int campaignId)
        {
            // 1. Kiểm tra xem chiến dịch có tồn tại không
            var campaign = await _repository.GetCampaignDetails(campaignId);
            if (campaign == null)
            {
                throw new ArgumentException($"Campaign with ID {campaignId} does not exist.");
            }

            // 2. Kiểm tra xem chiến dịch có dữ liệu vận hành không
            if (campaign.CampaignRobotMachines.Any() || campaign.RewardRules.Any())
            {
                throw new InvalidOperationException("Cannot delete a campaign that has operational data.");
            }

            // 3. Xóa chiến dịch
            await _repository.DeleteCampaign(campaign);
        }
    }
}
