using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class MaisonMappers
    {
        public static MaisonDto ToMaisonDto(this Maison maisonModel)
        {
            return new MaisonDto
            {
                Id = maisonModel.Id,
                Adresse = maisonModel.Adresse,
                Complement = maisonModel.Complement,
                CodePostal = maisonModel.CodePostal,
                Ville = maisonModel.Ville,
                TelDomicile = maisonModel.TelDomicile,
                Adherent = maisonModel.Adherent,
                Categorie = maisonModel.Categorie,
                Parent = maisonModel.Parent.ToList()

            };
        }

        public static Maison ToMaisonFromCreateDTO(this CreateMaisonRequestDto createMaisonRequestDto)
        {
            return new Maison
            {
                Adresse = createMaisonRequestDto.Adresse,
                Complement = createMaisonRequestDto.Complement,
                CodePostal = createMaisonRequestDto.CodePostal,
                Ville = createMaisonRequestDto.Ville,
                TelDomicile = createMaisonRequestDto.TelDomicile,
                Adherent = createMaisonRequestDto.Adherent,
                Categorie = createMaisonRequestDto.Categorie
            };
        }
    }
}
