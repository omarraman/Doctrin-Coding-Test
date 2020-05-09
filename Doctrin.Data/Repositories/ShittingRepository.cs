//Generated by Framework Code Generator5/7/2020 9:00:36 PM
using Doctrin.Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Doctrin.Core.Repositories;

namespace Doctrin.Data.Repositories
{
	public  class ShittingRepository : Repository<Shitting>, IShittingRepository	{
		private readonly MyDbContext _context;


		public ShittingRepository(MyDbContext context) : base(context)
		{
			 _context = context;
		}
		public async Task<Shitting> GetShittingByUnitAsync(int unitId, int id)
		{
			return await _context.Shittings.SingleOrDefaultAsync((m => m.UnitId ==  unitId && m.Id == id));
		}
		public async Task AddShittingByUnitAsync(int unitId, Shitting shitting)
		{
			shitting.UnitId =unitId;
			await _context.Shittings.AddAsync(shitting);
		}
	}
}
