using HeinekenRobot.Models;

namespace HeinekenRobot.Service.CampaignFolder
{
    public interface ICampaignService
    {
        Task<IEnumerable<object>> GetActiveCampaignSummaries();
        Task AddCampaign(Campaign campaign);
        Task<object> GetCampaignDetails(int campaignId);
        Task UpdateCampaign(int campaignId, Campaign updatedCampaign);
        Task DeleteCampaign(int campaignId);

    }
}
