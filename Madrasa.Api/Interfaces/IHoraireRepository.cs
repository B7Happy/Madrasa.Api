using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IHoraireRepository
    {
        Task<IEnumerable<Horaire>> GetAllAsync();
        Task<Horaire> CreateAsync(Horaire horaire);
        Task<Horaire> UpdateAsync(int id, Horaire horaire);
        Task<Horaire> GetByIdAsync(int id); 
    }
}
