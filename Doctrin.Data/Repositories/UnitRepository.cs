using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;

namespace Doctrin.Data.Repositories
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        public UnitRepository(MyDbContext context):base(context)
        {
        }
    }
}
