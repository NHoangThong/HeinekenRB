using HeinekenRobot.Models;
using HeinekenRobot.Repository.RoleFolder;

namespace HeinekenRobot.Service.RoleFolder
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _repository.GetAllRoles();
        }
        public async Task AddRoleAsync(Role role)
        {
            // Kiểm tra các điều kiện và logic nghiệp vụ trước khi thêm
            if (string.IsNullOrEmpty(role.RoleName) || string.IsNullOrEmpty(role.Description))
            {
                throw new ArgumentException("Role name and description are required.");
            }

            // Gọi Repository để thêm vai trò vào cơ sở dữ liệu
            await _repository.AddRoleAsync(role);
        }
        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _repository.GetRoleByIdAsync(roleId);
        }
        public async Task UpdateRoleAsync(Role role)
        {
            // Thực hiện kiểm tra logic nghiệp vụ trước khi cập nhật
            if (string.IsNullOrWhiteSpace(role.RoleName))
            {
                throw new ArgumentException("Role name cannot be empty.");
            }

            await _repository.UpdateRoleAsync(role);
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            // Kiểm tra nếu vai trò được gán cho người dùng
            if (await _repository.IsRoleAssignedToUsers(roleId))
            {
                throw new InvalidOperationException("Cannot delete a role that is assigned to users.");
            }

            // Thực hiện xóa vai trò
            await _repository.DeleteRoleAsync(roleId);
        }
    }
}
