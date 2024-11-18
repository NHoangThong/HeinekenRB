using HeinekenRobot.Models;
using HeinekenRobot.Repository;

namespace HeinekenRobot.Service
{
    public class RecycleMachineService:IRecycleMachineService
    {
        private readonly IRecycleMachineRepository _repository;

        public RecycleMachineService(IRecycleMachineRepository repository) {
            _repository = repository;
        }
        public async Task<IEnumerable<RecycleMachine>> GetMachines()
        {
            return await _repository.GetALl();
        }

        public async Task Add_Machine(RecycleMachine recycleMachine)
        {
            await _repository.Add_Machine(recycleMachine);
        }

        public async Task<RecycleMachine> GetMachineDetail(string machineId)
        {
            return await _repository.GetMachineDetail(machineId);
        }

        public async Task Upadate_Machine(RecycleMachine machine)
        {
            var find_machine = await _repository.GetMachineDetail(machine.MachineId);

            if (find_machine == null) {
                throw new KeyNotFoundException("Not found.");
            }
            find_machine.MachineId = machine.MachineId;
            find_machine.Status = machine.Status;
            find_machine.ContainerStatus = machine.ContainerStatus;
            find_machine.LastServiceDate = machine.LastServiceDate;
            find_machine.LocationId = machine.LocationId;
            find_machine.Interactions = machine.Interactions;
            await _repository.Upadate_Machine(find_machine);
        }
        public async Task Delete_machine(string machineId)
        {
            var machine= await _repository.GetMachineDetail(machineId);
            if (machine == null)
            {
                throw new KeyNotFoundException("Recycle machine not found.");
            }

            // Kiểm tra nếu máy đã vận hành (LastServiceDate đã thiết lập)
            if (machine.LastServiceDate != DateTime.MinValue)
            {
                throw new InvalidOperationException("Cannot delete a recycle machine that has been operated.");
            }

            await _repository.Delete_machine(machineId);
        }
    }
}
