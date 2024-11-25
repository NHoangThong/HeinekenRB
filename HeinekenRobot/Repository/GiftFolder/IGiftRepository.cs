using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.GiftFolder
{
    public interface IGiftRepository
    {
        Task<IEnumerable<Gift>> GetAllGifts();
        Task AddGift(Gift gift);
        Task<Gift?> GetGiftById(int giftId);
        Task UpdateGift(Gift gift);
        Task<bool> DeleteGift(int giftId);

      
    }
}
