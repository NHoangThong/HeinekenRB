using System.ComponentModel.DataAnnotations;

namespace HeinekenRobot.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)] 
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        public int PointsBalance { get; set; } = 0;

        
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
