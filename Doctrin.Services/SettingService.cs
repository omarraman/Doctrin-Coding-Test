using System;
using System.Threading.Tasks;
using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;
using Doctrin.Core.Services;

namespace Doctrin.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Setting> AddAsync(int unitId, Setting settingToCreate)
        {
            await _unitOfWork.Settings.Add(unitId,settingToCreate);
            await _unitOfWork.CommitAsync();
            return settingToCreate;
        }

        public async Task DeleteAsync(Setting settingToDelete)
        {
            _unitOfWork.Settings.Remove(settingToDelete);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Setting> GetSettingByUnitAsync(int unitId, string globalId)
        {
            return await _unitOfWork.Settings.GetSettingByUnitAsync(unitId,globalId);
        }

        public async Task UpdateAsync(Setting settingToUpdate, Setting setting)
        {
            settingToUpdate.GlobalId = setting.GlobalId;
            settingToUpdate.Value = setting.Value;
            settingToUpdate.Inheritable = setting.Inheritable;

            await _unitOfWork.CommitAsync();

        }
    }
}
