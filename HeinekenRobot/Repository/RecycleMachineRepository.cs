using HeinekenRobot.Data;
using HeinekenRobot.Models;
using Microsoft.EntityFrameworkCore;

namespace HeinekenRobot.Repository
{
    public class RecycleMachineRepository: IRecycleMachineRepository
    {
        private readonly HeniekenDbContext _context;

        public RecycleMachineRepository(HeniekenDbContext context)
        {
            _context= context;
        }

        public async Task<IEnumerable<RecycleMachine>> GetALl()
        {
            return await _context.RecycleMachines.Include(m=>m.Location).ToListAsync();
        }

        public async Task Add_Machine(RecycleMachine recycleMachine)
        {
            await _context.RecycleMachines.AddAsync(recycleMachine);
            await _context.SaveChangesAsync();
        }

        public async Task<RecycleMachine> GetMachineDetail(int machineId)
        {
            return await _context.RecycleMachines.Include(m => m.Location).Include(m => m.CampaignRobotMachines).FirstOrDefaultAsync(m => m.MachineId == machineId);
        }

        public async Task Upadate_Machine(RecycleMachine machine)
        {
             _context.RecycleMachines.Update(machine);
            await _context.SaveChangesAsync();
        }
    }
}
