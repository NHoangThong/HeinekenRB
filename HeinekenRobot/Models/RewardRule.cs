using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class RewardRule
    {
        [Key]
        public int RuleId { get; set; }
        public int CampaignId { get; set; }
        public int PointRangeMin { get; set; }
        public int PointRangeMax { get; set; }
        public int GiftId { get; set; }
        public decimal GiftChance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Liên kết với các bảng khác
        public Campaign? Campaign { get; set; }
        public Gift? Gift { get; set; }
    }
}
