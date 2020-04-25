using System.Threading.Tasks;
using Doctrin.Core.Entities;

namespace Doctrin.Core.Services
{
    public interface IUnitService
    {
        Task<Unit> GetAsync(int id);
        Task DeleteAsync(Unit unitToDelete);

        Task<Unit> AddAsync(Unit unitToCreate);

    }
}
