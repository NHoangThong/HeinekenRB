using HeinekenRobot.Models;

namespace HeinekenRobot.Service.RecycleMachineFolder
{
    public interface IRecycleMachineService
    {
        Task<IEnumerable<RecycleMachine>> GetMachines();
        Task Add_Machine(RecycleMachine recycleMachine);
        Task<RecycleMachine> GetMachineDetail(string machineId);
        Task Upadate_Machine(RecycleMachine machine);
        Task Delete_machine(string machineId);
    }
}
