using HeinekenRobot.Models;

namespace HeinekenRobot.Service
{
    public interface IRobotService
    {
        Task<IEnumerable<Robot>> GetRobots();
        Task<Robot> GetRobotId(int id);
        Task AddRobot(Robot robot);
        Task UpdateRobot(Robot robot);

        Task DeleteRobot(int robotId);
    }
}
