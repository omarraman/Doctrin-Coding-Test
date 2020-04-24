using System.Threading.Tasks;

namespace Doctrin.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUnitRepository Units { get; }
        ISettingRepository Settings { get; }
        Task<int> CommitAsync();
    }
}
