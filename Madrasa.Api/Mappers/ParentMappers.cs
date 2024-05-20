using Madrasa.Api.Dtos.Parent;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class ParentMappers
    {
        public static ParentDto ToParentDto(this Parent parentModel)
        {
            return new ParentDto
            {
                Id = parentModel.Id,
                Type = parentModel.Type,
                Nom = parentModel.Nom,
                Prenom = parentModel.Prenom,
                TelMobile = parentModel.TelMobile,
                Email = parentModel.Email,
                MaisonId = parentModel.MaisonId
            };
        }

        public static Parent ToParentFromCreateDTO(this CreateParentRequestDto createParentRequestDto)
        {
            return new Parent
            {
                Type = createParentRequestDto.Type,
                Nom = createParentRequestDto.Nom,
                Prenom = createParentRequestDto.Prenom,
                TelMobile = createParentRequestDto.TelMobile,
                Email = createParentRequestDto.Email,
            };
        }

        public static Parent ToParent(this Parent parentModel)
        {
            return new Parent
            {
                Id = parentModel.Id,
                Type = parentModel.Type,
                Nom = parentModel.Nom,
                Prenom = parentModel.Prenom,
                TelMobile = parentModel.TelMobile,
                Email = parentModel.Email,
                MaisonId = parentModel.MaisonId
            };
        }
    }
}
