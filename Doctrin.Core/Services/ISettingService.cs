using System.Threading.Tasks;
using Doctrin.Core.Entities;

namespace Doctrin.Core.Services
{
    public interface ISettingService
    {
        Task<Setting> GetSettingByUnitAsync(int unitId, string globalId);
        Task DeleteAsync(Setting settingToDelete);

        Task<Setting> AddAsync(int unitId, Setting settingToCreate);

        Task UpdateAsync(Setting settingToUpdate, Setting setting);

    }
}
