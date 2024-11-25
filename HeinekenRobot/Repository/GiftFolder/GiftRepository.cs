using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository.GiftFolder
{
    public class GiftRepository:IGiftRepository
    {
        private readonly HeniekenDbContext _context;

        public GiftRepository(HeniekenDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Gift>> GetAllGifts()
        {
            return await _context.Gifts.ToListAsync();
        }

        public async Task AddGift(Gift gift)
        {
            await _context.Gifts.AddAsync(gift);
            await _context.SaveChangesAsync();
        }
        public async Task<Gift?> GetGiftById(int giftId)
        {
            return await _context.Gifts.FirstOrDefaultAsync(g => g.GiftId == giftId);
        }
        public async Task UpdateGift(Gift gift)
        {
            _context.Gifts.Update(gift);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteGift(int giftId)
        {
            var gift = await _context.Gifts.FindAsync(giftId);
            if (gift == null)
            {
                return false;
            }

            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
            return true;
        }

        // Lấy danh sách các quà tặng dựa trên danh sách GiftId
      
    }
}
