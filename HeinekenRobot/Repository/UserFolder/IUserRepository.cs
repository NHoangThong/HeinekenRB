using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.UserFolder
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task AddUser(User user);
        Task<bool> IsUsernameUnique(string username);
        Task<User?> GetUserById(int userId);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
