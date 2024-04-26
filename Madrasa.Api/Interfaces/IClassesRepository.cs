using Madrasa.Api.Dtos.Classes;
using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IClassesRepository
    {
        Task<IEnumerable<Classes>> GetAllAsync();
        Task<Classes?> GetByIdAsync(int id);
        Task<Classes> CreateAsync(Classes classe);
        Task<Classes> UpdateAsync(int id, UpdateClassesRequestDto classe);
        Task<Classes> DeleteAsync(int id);
    }
}
