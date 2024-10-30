namespace HeinekenRobot.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }= string.Empty;
        public int RegionId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Liên kết với Region
        public  Region? Region { get; set; }
    }
}
