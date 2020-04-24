using System.Threading.Tasks;
using Doctrin.Core.Entities;

namespace Doctrin.Core.Services
{
    public interface IUnitService
    {
        Task<Unit> GetAsync(int id);
        Task Delete(Unit unitToDelete);

        Task<Unit> Add(Unit unitToCreate);

    }
}
