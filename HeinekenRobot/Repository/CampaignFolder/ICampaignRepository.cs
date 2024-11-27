using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.CampaignFolder
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> GetActiveCampaigns();
        Task AddCampaign(Campaign campaign);
        Task<Campaign> GetCampaignDetails(int campaignId);
        Task UpdateCampaign(Campaign campaign);
        Task DeleteCampaign(Campaign campaign);
    }
}
