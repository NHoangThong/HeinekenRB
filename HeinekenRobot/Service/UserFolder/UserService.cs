using HeinekenRobot.Models;
using HeinekenRobot.Repository.UserFolder;

namespace HeinekenRobot.Service.UserFolder
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }
        public async Task AddUser(User user)
        {
            // Kiểm tra tính duy nhất của Username
            if (!await IsUsernameUnique(user.Username))
            {
                throw new ArgumentException("Username already exists.");
            }

            // Thêm người dùng mới vào hệ thống
            await _repository.AddUser(user);
        }

        public async Task<bool> IsUsernameUnique(string username)
        {
            return await _repository.IsUsernameUnique(username);
        }
        public async Task<User?> GetUserById(int userId)
        {
            return await _repository.GetUserById(userId);
        }
        public async Task UpdateUser(User updatedUser)
        {
            var existingUser = await _repository.GetUserById(updatedUser.UserId);

            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {updatedUser.UserId} not found.");
            }

            // Không cho phép cập nhật Username hoặc Password
            existingUser.FullName = updatedUser.FullName;
            existingUser.Email = updatedUser.Email;
            existingUser.Role = updatedUser.Role;

            await _repository.UpdateUser(existingUser);
        }
        public async Task DeleteUser(int userId)
        {
            var user = await _repository.GetUserById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            await _repository.DeleteUser(userId);
        }
    }
}
