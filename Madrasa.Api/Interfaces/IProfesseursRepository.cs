using Madrasa.Api.Dtos.Professeurs;
using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IProfesseursRepository
    {
        Task<IEnumerable<Professeurs>> GetAllAsync();
        Task<Professeurs?> GetByIdAsync(int id);
        Task<Professeurs> CreateAsync(Professeurs professeurs);
        Task<Professeurs> UpdateAsync(int id, UpdateProfesseursRequestDto professeurs);
        Task<Professeurs> DeleteAsync(int id);
    }
}
