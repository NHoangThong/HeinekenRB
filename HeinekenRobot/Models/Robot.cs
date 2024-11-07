using System.Text.Json.Serialization;

namespace HeinekenRobot.Models
{
    public class Robot
    {
        public int RobotId { get; set; }
        public string RobotName { get; set; } = string.Empty;
        public string RobotTypeId { get; set; } = string.Empty;
        public string Status { get; set; }= string.Empty;
        public DateTime LastAccessTime { get; set; }
        public int BatteryLevel { get; set; }
       
        public int LocationId { get; set; }

        // Liên kết với Location
        public Location? Location { get; set; }

        [JsonIgnore]
        public RobotType? RobotType { get; set; }
        [JsonIgnore]
        public virtual ICollection<CampaignRobotMachine> CampaignRobotMachines { get; set; } = new List<CampaignRobotMachine>();
    }
}
