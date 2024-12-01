using HeinekenRobot.Models;

namespace HeinekenRobot.Service.UserFolder
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task AddUser(User user);
        Task<bool> IsUsernameUnique(string username);
        Task<User?> GetUserById(int userId);
        Task UpdateUser(User updatedUser);
        Task DeleteUser(int userId);
    }
}
