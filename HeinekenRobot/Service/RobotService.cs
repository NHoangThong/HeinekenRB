using HeinekenRobot.Models;
using HeinekenRobot.Repository;

namespace HeinekenRobot.Service
{
    public class RobotService:IRobotService
    {
        private readonly IRobotRepository _repository;

        public RobotService(IRobotRepository repository) {
            _repository=repository;
        }

        public async Task<IEnumerable<Robot>> GetRobots()
        {
            var robots = await _repository.GetAll();
            return robots;
        }

        public async Task<Robot> GetRobotId(int id)
        {
            return await _repository.GetRobotById(id); 

        }
        public async Task AddRobot(Robot robot)
        {
            await _repository.AddRobot(robot);
        }
    }
}
