using System.Threading.Tasks;
using Doctrin.Core.Entities;

namespace Doctrin.Core.Repositories
{
    public interface ISettingRepository: IRepository<Setting>
    {
        Task<Setting> GetSettingByUnitAsync(int unitId, string globalId);
        void Delete(Setting settingToRemove);
        Task AddSettingForUnitAsync(int unitId, Setting settingToAdd);


    }
}
