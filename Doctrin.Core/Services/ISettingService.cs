using System.Threading.Tasks;
using Doctrin.Core.Entities;

namespace Doctrin.Core.Services
{
    public interface ISettingService
    {
        Task<Setting> GetSettingByUnit(int unitId, string globalId);
        Task Delete(Setting settingToDelete);

        Task<Setting> Add(int unitId, Setting settingToCreate);

        Task Update(Setting settingToUpdate, Setting setting);


        //public async Task Add(Setting settingToAdd)
        //{
        //    await _context.Settings.AddAsync(settingToAdd);
        //}

        //public async Task Delete(Setting settingToRemove)
        //{
        //    _context.Settings.Remove(settingToRemove);
        //}

        //public async Task<Setting> GetSettingByUnit(int unitId, string globalId)
        //{
        //    return await _context.Settings.SingleAsync((m => m.UnitId == unitId && m.GlobalId == globalId);
        //}

    }
}
