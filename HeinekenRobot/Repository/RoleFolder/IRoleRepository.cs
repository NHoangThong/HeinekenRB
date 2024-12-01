using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.RoleFolder
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task AddRoleAsync(Role role);
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int roleId);
        Task<bool> IsRoleAssignedToUsers(int roleId);
    }
}
