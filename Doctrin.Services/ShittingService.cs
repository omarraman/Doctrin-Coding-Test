//Generated by Framework Code Generator5/7/2020 9:00:36 PM
using Doctrin.Core.Entities;
using System.Threading.Tasks;
using Doctrin.Core.Repositories;
using Doctrin.Core.Services;

namespace Doctrin.Services
{
	public  class ShittingService : IShittingService	{
		private readonly IUnitOfWork _unitOfWork;


		public ShittingService(IUnitOfWork unitOfWork) 
		{
			this._unitOfWork = unitOfWork;
		}
		public async Task<Shitting> GetShittingByUnitAsync(int unitId, int id)
		{
			return await _unitOfWork.Shittings.GetShittingByUnitAsync(unitId, id);
		}
		public async Task<Shitting> AddShittingByUnitAsync(int unitId, Shitting shitting)
		{
			await _unitOfWork.Shittings.AddShittingByUnitAsync(unitId,shitting);
			await _unitOfWork.CommitAsync();
			return shitting;
		}
		public async Task DeleteAsync(Shitting shitting)
		{
			_unitOfWork.Shittings.Remove(shitting);
			await _unitOfWork.CommitAsync();
		}
	}
}