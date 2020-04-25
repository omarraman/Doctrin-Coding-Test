using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Doctrin.Data.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly MyDbContext _context;

        public SettingRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Add(int unitId, Setting settingToAdd)
        {
            settingToAdd.UnitId = unitId;
            await _context.Settings.AddAsync(settingToAdd);
        }

        public async Task Delete(Setting settingToRemove)
        {
            _context.Settings.Remove(settingToRemove);
        }

        public async Task<Setting> GetSettingByUnitAsync(int unitId, string globalId)
        {
            return await _context.Settings.SingleOrDefaultAsync((m => m.UnitId == unitId && m.GlobalId == globalId));
        }



    }
}
