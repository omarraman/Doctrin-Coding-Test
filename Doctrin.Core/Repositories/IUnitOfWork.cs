using System.Threading.Tasks;

namespace Doctrin.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUnitRepository Units { get; }
        ISettingRepository Settings { get; }
        IShittingRepository Shittings { get; }
        ICrappingRepository Crappings { get; }
        Task<int> CommitAsync();
    }
}
