using HeinekenRobot.Models;

namespace HeinekenRobot.Service
{
    public interface IRecycleMachineService
    {
        Task<IEnumerable<RecycleMachine>> GetMachines();
        Task Add_Machine(RecycleMachine recycleMachine);
        Task<RecycleMachine> GetMachineDetail(int machineId);
        Task Upadate_Machine(RecycleMachine machine);
    }
}
