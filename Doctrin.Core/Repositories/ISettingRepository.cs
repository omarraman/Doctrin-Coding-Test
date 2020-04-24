using System.Threading.Tasks;
using Doctrin.Core.Entities;

namespace Doctrin.Core.Repositories
{
    public interface ISettingRepository: IRepository<Setting>
    {
        Task<Setting> GetSettingByUnit(int unitId, string globalId);
        Task Delete(Setting settingToRemove);

        Task Add(int unitId, Setting settingToAdd);


    }
}
