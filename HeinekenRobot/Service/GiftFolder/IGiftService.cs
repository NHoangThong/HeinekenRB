using HeinekenRobot.Models;

namespace HeinekenRobot.Service.GiftFolder
{
    public interface IGiftService
    {
        Task<IEnumerable<Gift>> GetAllGifts();
        Task AddGift(Gift gift);
        Task<Gift?> GetGiftById(int giftId);
        Task UpdateGift(int giftId, Gift updatedGift);
        Task<bool> DeleteGift(int giftId);
    }
}
