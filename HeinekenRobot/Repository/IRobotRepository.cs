using HeinekenRobot.Models;

namespace HeinekenRobot.Repository
{
    public interface IRobotRepository
    {
        Task<IEnumerable<Robot>> GetAll();
    }
}
