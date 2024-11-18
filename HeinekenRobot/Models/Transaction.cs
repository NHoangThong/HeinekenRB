namespace HeinekenRobot.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CampaignId { get; set; }
        public int RobotId { get; set; }
        public string MachineId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int PointsEarned { get; set; } = 0;
        public int GiftId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Liên kết với các bảng khác
        public Campaign? Campaign { get; set; }
        public Robot? Robot { get; set; }
        public RecycleMachine? Machine { get; set; }
        public Location? Location { get; set; }
        public Customer? Customer { get; set; }
        public Gift? Gift { get; set; }
    }
}
