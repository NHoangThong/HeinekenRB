﻿namespace HeinekenRobot.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Liên kết với bảng User
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
