using HeinekenRobot.Models;

namespace HeinekenRobot.Repository
{
    public interface IRobotRepository
    {
        Task<IEnumerable<Robot>> GetAll();
        Task<Robot> GetRobotById(int id);
        Task AddRobot(Robot robot);
        Task UpdateRobot(Robot robot);
        Task DeleteRobot(int id);   
    }
}
