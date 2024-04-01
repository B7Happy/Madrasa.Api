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
                Categorie = maisonModel.Categorie
            };
        }
    }
}
