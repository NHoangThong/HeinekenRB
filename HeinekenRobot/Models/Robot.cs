namespace HeinekenRobot.Models
{
    public class Robot
    {
        public int RobotId { get; set; }
        public string RobotCode { get; set; }=string.Empty;
        public string RobotType { get; set; } = string.Empty;
        public string Status { get; set; }= string.Empty;
        public DateTime LastAccessTime { get; set; }
        public int BatteryLevel { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int LocationId { get; set; }

        // Liên kết với Location
        public Location ?Location { get; set; }

        public virtual ICollection<CampaignRobotMachine> CampaignRobotMachines { get; set; } = new List<CampaignRobotMachine>();
    }
}
