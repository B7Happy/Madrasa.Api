using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
