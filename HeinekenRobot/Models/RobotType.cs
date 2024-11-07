using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class RobotType
    {
        [Key]
        [MaxLength(50)]
        public string RobotTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }

        // Liên kết với Robot
        public ICollection<Robot> Robots { get; set; } = new List<Robot>();
    }
}
