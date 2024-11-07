using System.Text.Json.Serialization;

namespace HeinekenRobot.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }= string.Empty;
        public int RegionId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


        // Liên kết với Region
        [JsonIgnore]
        public  Region? Region { get; set; }
        [JsonIgnore]
        public virtual ICollection<CampaignRobotMachine> CampaignRobotMachines { get; set; } = new List<CampaignRobotMachine>();
    }
}
