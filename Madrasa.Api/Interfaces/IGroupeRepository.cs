using Madrasa.Api.Dtos.Groupe;
using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IGroupeRepository
    {
        Task<IEnumerable<Groupe>> GetAllAsync();
        Task<Groupe> CreateAsync(Groupe groupe);
        Task<Groupe> UpdateAsync(int id, UpdateGroupe groupe);
        Task<Groupe> DeleteAsync(int id);
    }
}
