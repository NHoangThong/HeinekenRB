using HeinekenRobot.Models;

namespace HeinekenRobot.Repository
{
    public interface IRecycleMachineRepository
    {
        Task<IEnumerable<RecycleMachine>> GetALl();
        Task Add_Machine(RecycleMachine recycleMachine);
        Task<RecycleMachine> GetMachineDetail(int machineId);
        Task Upadate_Machine(RecycleMachine machine);
    }
}
