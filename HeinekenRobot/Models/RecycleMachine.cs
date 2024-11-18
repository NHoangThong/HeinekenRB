using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class RecycleMachine
    {
        [Key]
        public string MachineId { get; set; } = string.Empty;
        //public string MachineCode { get; set; } 
        public string Status { get; set; } = string.Empty;
        public string ContainerStatus { get; set; } = string.Empty;
        public DateTime LastServiceDate { get; set; } 
        public int LocationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Ngày thêm vào hệ thống
        public int Interactions { get; set; } = 0;

        // Liên kết với Location
        public Location? Location { get; set; }

        public virtual ICollection<CampaignRobotMachine> CampaignRobotMachines { get; set; } = new List<CampaignRobotMachine>();
    }
}
