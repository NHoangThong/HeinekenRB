using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class CampaignRobotMachine
    {
        [Key]
        public int CampaignRobotMachineId { get; set; }

        public int CampaignId { get; set; }
        public int RobotId { get; set; }
        public int MachineId { get; set; }
        public int LocationId { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; }

        // Liên kết với các bảng khác
        [ForeignKey("CampaignId")]
        public Campaign Campaign { get; set; }

        [ForeignKey("RobotId")]
        public Robot Robot { get; set; }

        [ForeignKey("MachineId")]
        public RecycleMachine Machine { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
