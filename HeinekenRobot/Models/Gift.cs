namespace HeinekenRobot.Models
{
    public class Gift
    {
        public int GiftId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TotalCount { get; set; } = 0;
        public int RedeemedCount { get; set; } = 0;
        public int ExpiredCount { get; set; } = 0;

        public virtual ICollection<RewardRule> RewardRules { get; set; } = new List<RewardRule>();
        public virtual ICollection<GiftRedemption> GiftRedemptions { get; set; } = new List<GiftRedemption>();

    }
}
