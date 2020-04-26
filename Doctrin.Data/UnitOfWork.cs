using System.Threading.Tasks;
using Doctrin.Core.Repositories;
using Doctrin.Data.Repositories;

namespace Doctrin.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private IUnitRepository _unitRepository;
        private ISettingRepository _settingRepository;
        public UnitOfWork(MyDbContext context)
        {
            this._context = context;
        }

        public IUnitRepository Units => _unitRepository = _unitRepository ?? new UnitRepository(_context);

        public ISettingRepository Settings =>
            _settingRepository = _settingRepository ?? new SettingRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
