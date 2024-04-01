using Madrasa.Api.Dtos.Horaire;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class HoraireMappers
    {
        public static HoraireDto ToHoraireDto(this Horaire horaireModel)
        {
            return new HoraireDto
            {
                Id = horaireModel.Id,
                NumJour = horaireModel.NumJour,
                Jour = horaireModel.Jour,
                HDeb = horaireModel.HDeb,
                HFin = horaireModel.HFin,
                Duree = horaireModel.Duree,
                GroupeId = horaireModel.GroupeId
            };
        }
    }
}
