using HeinekenRobot.Models;

namespace HeinekenRobot.Service
{
    public interface IRobotService
    {
        Task<IEnumerable<Robot>> GetRobots();
    }
}
