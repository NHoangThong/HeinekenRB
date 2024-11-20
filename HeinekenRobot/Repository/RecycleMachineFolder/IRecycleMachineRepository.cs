using HeinekenRobot.Models;

namespace HeinekenRobot.Repository.RecycleMachineFolder
{
    public interface IRecycleMachineRepository
    {
        Task<IEnumerable<RecycleMachine>> GetALl();
        Task Add_Machine(RecycleMachine recycleMachine);
        Task<RecycleMachine> GetMachineDetail(string machineId);
        Task Upadate_Machine(RecycleMachine machine);

        Task Delete_machine(string machineId);
    }
}
