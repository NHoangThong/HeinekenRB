using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository.RoleFolder
{
    public class RoleRepository:IRoleRepository
    {
        private readonly HeniekenDbContext _context;

        public RoleRepository(HeniekenDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles
                                 .Include(r => r.Users) // Load số lượng tài khoản người dùng cho mỗi vai trò
                                 .ToListAsync();
        }
        public async Task AddRoleAsync(Role role)
        {
            // Kiểm tra nếu vai trò đã tồn tại trong cơ sở dữ liệu
            var existingRole = await _context.Roles
                                              .FirstOrDefaultAsync(r => r.RoleName == role.RoleName);
            if (existingRole != null)
            {
                throw new ArgumentException("Role already exists.");
            }

            // Thêm vai trò mới vào cơ sở dữ liệu
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }
        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles
                                 .Include(r => r.Users) // Load thông tin người dùng liên quan
                                 .FirstOrDefaultAsync(r => r.RoleId == roleId);
        }
        public async Task UpdateRoleAsync(Role role)
        {
            var existingRole = await GetRoleByIdAsync(role.RoleId);
            if (existingRole == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            // Cập nhật thông tin vai trò
            existingRole.RoleName = role.RoleName;
            existingRole.Description = role.Description;

            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var role = await GetRoleByIdAsync(roleId);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsRoleAssignedToUsers(int roleId)
        {
            return await _context.Users.AnyAsync(u => u.RoleId == roleId);
        }
    }
}
