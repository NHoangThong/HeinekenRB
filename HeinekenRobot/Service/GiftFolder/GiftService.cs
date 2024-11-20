using HeinekenRobot.Models;
using HeinekenRobot.Repository.GiftFolder;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Service.GiftFolder
{
    public class GiftService:IGiftService
    {
        private readonly IGiftRepository _repository;

        public GiftService(IGiftRepository repository) {
            _repository = repository;
        }
        public async Task<IEnumerable<Gift>> GetAllGifts()
        {
            return await _repository.GetAllGifts();
        }

        public async Task AddGift(Gift gift)
        {
            // Kiểm tra tính hợp lệ
            if (string.IsNullOrWhiteSpace(gift.Name))
            {
                throw new ArgumentException("Gift name cannot be empty.");
            }

            if (gift.TotalCount < 0)
            {
                throw new ArgumentException("Total count cannot be negative.");
            }

            await _repository.AddGift(gift);
        }

        public async Task<Gift?> GetGiftById(int giftId)
        {
            var gift = await _repository.GetGiftById(giftId);
            return gift;
        }
        public async Task UpdateGift(int giftId, Gift updatedGift)
        {
            var existingGift = await _repository.GetGiftById(giftId);

            if (existingGift == null)
            {
                throw new KeyNotFoundException("Gift not found.");
            }

            // Cập nhật các thuộc tính cho phép
            existingGift.Name = updatedGift.Name ?? existingGift.Name;
            existingGift.Description = updatedGift.Description ?? existingGift.Description;
            existingGift.TotalCount = updatedGift.TotalCount > 0 ? updatedGift.TotalCount : existingGift.TotalCount;

            await _repository.UpdateGift(existingGift);
        }

        public async Task<bool> DeleteGift(int giftId)
        {
            return await _repository.DeleteGift(giftId);
        }
    }
}
