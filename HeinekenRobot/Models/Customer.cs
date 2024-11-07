namespace HeinekenRobot.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PointsBalance { get; set; } = 0;
        

        // Liên kết với bảng Transaction
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
