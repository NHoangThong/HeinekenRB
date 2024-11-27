namespace HeinekenRobot.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }= string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int RegionId { get; set; }
      

        // Liên kết với Region
        public Region ? Region { get; set; }

        public virtual ICollection<CampaignRobotMachine> CampaignRobotMachines { get; set; } = new List<CampaignRobotMachine>();

        public virtual ICollection<RewardRule> RewardRules { get; set; } = new List<RewardRule>();
    }
}
