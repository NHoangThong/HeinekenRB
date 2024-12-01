using HeinekenRobot.Models;

namespace HeinekenRobot.Service.RoleFolder
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task AddRoleAsync(Role role);
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int roleId);
    }
}
