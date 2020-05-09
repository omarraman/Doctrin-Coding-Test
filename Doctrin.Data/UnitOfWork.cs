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
        private IShittingRepository _shittingRepository;
        private ICrappingRepository _crappingRepository;

        public UnitOfWork(MyDbContext context)
        {
            this._context = context;
        }

        public IUnitRepository Units => _unitRepository = _unitRepository ?? new UnitRepository(_context);
        public IShittingRepository Shittings => _shittingRepository = _shittingRepository?? new ShittingRepository(_context);
        public ICrappingRepository Crappings => _crappingRepository = _crappingRepository ?? new CrappingRepository(_context);

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
