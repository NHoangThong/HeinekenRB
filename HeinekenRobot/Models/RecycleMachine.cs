using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class RecycleMachine
    {
        [Key]
        public int MachineId { get; set; }
        public string MachineCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ContainerStatus { get; set; } = string.Empty;
        public DateTime LastServiceDate { get; set; }
        public int LocationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Liên kết với Location
        public Location? Location { get; set; }

        public virtual ICollection<CampaignRobotMachine> CampaignRobotMachines { get; set; } = new List<CampaignRobotMachine>();
    }
}
