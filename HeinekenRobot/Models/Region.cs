namespace HeinekenRobot.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }=string.Empty;
        public string Province { get; set; } = string.Empty;    
        

        // Liên kết với Location
        public ICollection<Location>? Locations { get; set; }
    }
}
