using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class ElevesMappers
    {
        public static ElevesDto ToEleveDto(this Eleves eleveModel)
        {
            return new ElevesDto
            {
                Id = eleveModel.Id,
                SN = eleveModel.SN,
                Suspendu = eleveModel.Suspendu,
                Nom = eleveModel.Nom,
                Prenom = eleveModel.Prenom,
                Sexe = eleveModel.Sexe,
                DateNaissance = eleveModel.DateNaissance,
                LieuNaissance = eleveModel.LieuNaissance,
                TelMobile = eleveModel.TelMobile,
                Email = eleveModel.Email,
                MaisonId = eleveModel.MaisonId,
                ClassesId = eleveModel.ClassesId,
                DateEntree = eleveModel.DateEntree
            };
        }

        public static Eleves ToElevesFromCreateDTO(this CreateEleveRequestDto eleveModel)
        {
            return new Eleves
            {
                SN = eleveModel.SN,
                Suspendu = eleveModel.Suspendu,
                Nom = eleveModel.Nom,
                Prenom = eleveModel.Prenom,
                Sexe = eleveModel.Sexe,
                DateNaissance = eleveModel.DateNaissance,
                LieuNaissance = eleveModel.LieuNaissance,
                TelMobile = eleveModel.TelMobile,
                Email = eleveModel.Email,
                MaisonId = eleveModel.MaisonId,
                ClassesId = eleveModel.ClassesId,
                DateEntree = eleveModel.DateEntree
            };
        }
    }
}
