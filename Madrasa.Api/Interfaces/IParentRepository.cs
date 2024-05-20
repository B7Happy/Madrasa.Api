using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Dtos.Parent;
using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IParentRepository
    {
        Task<Parent> UpdateAsync(int id, UpdateParentRequestDto parent);
        Task<Parent> CreateAsync(Parent parent);
    }
}
