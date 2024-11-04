using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class GiftRedemption
    {
        [Key]
        public int RedemptionId { get; set; }
        public int CampaignId { get; set; }
        public int GiftId { get; set; }
        public int UserId { get; set; }
        public DateTime RedemptionDate { get; set; } = DateTime.Now;
        public string QrCode { get; set; }
        public string Status { get; set; }
        public DateTime? RedeemedAt { get; set; }

        // Liên kết với các bảng khác
        public Campaign? Campaign { get; set; }
        public Gift? Gift { get; set; }
        public User? User { get; set; }
    }
}
