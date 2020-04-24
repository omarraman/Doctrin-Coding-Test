using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctrin.Data.Repositories
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        public UnitRepository(MyDbContext context):base(context)
        {
        }
    }
}
