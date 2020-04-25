using System;
using System.Threading.Tasks;
using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;
using Doctrin.Core.Services;

namespace Doctrin.Services
{
    public class UnitService : IUnitService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Unit> AddAsync(Unit unitToCreate)
        {
            await _unitOfWork.Units.AddAsync(unitToCreate);
            await _unitOfWork.CommitAsync();
            return unitToCreate;
        }

        public async Task DeleteAsync(Unit unitToDelete)
        {
            _unitOfWork.Units.Remove(unitToDelete);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Unit> GetAsync(int id)
        {
            return await _unitOfWork.Units.GetByIdAsync(id);
        }
    }
}
