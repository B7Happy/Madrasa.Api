using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IMaisonRepository
    {
        Task<IEnumerable<Maison>> GetAllAsync();
        Task<Maison?> GetByIdAsync(int id);
        Task<Maison> CreateAsync(Maison maison);
        Task<Maison> UpdateAsync(int id, UpdateMaisonRequestDto maison);
        Task<Maison> DeleteAsync(int id);
    }
}
