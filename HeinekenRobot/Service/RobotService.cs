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

        public async Task UpdateRobot(Robot robot)
        {
            var existRobot = await _repository.GetRobotById(robot.RobotId);
            if (existRobot == null)
            {
                throw new KeyNotFoundException("Robot not found.");
            }
            //existRobot.LastAccessTime = robot.LastAccessTime;
            existRobot.RobotName = robot.RobotName;
            existRobot.Status = robot.Status;
            existRobot.BatteryLevel = robot.BatteryLevel;
            existRobot.LocationId = robot.LocationId;
            await _repository.UpdateRobot(existRobot);
        }

        public async Task DeleteRobot(int robotId)
        {
            await _repository.DeleteRobot(robotId);

        }
    }
}
