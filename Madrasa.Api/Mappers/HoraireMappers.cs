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

        public static Horaire ToHoraireFromCreateHoraireDto(this CreateHoraireDto createHoraireDto)
        {
            TimeSpan heureDebut = TimeSpan.Parse(createHoraireDto.HDeb);
            TimeSpan heureFin = TimeSpan.Parse(createHoraireDto.HFin);
            TimeSpan duree = heureFin - heureDebut;
            return new Horaire
            {
                NumJour = createHoraireDto.NumJour,
                Jour = createHoraireDto.Jour,
                HDeb = heureDebut,
                HFin = heureFin,
                Duree = duree,
                GroupeId = createHoraireDto.GroupeId
            };
        }

        public static Horaire ToHoraireFromEditHoraireDto(this EditHoraireDto editHoraireDto)
        {
            TimeSpan heureDebut = TimeSpan.Parse(editHoraireDto.HDeb);
            TimeSpan heureFin = TimeSpan.Parse(editHoraireDto.HFin);
            TimeSpan duree = heureFin - heureDebut;
            return new Horaire
            {
                Id = editHoraireDto.Id,
                NumJour = editHoraireDto.NumJour,
                Jour = editHoraireDto.Jour,
                HDeb = heureDebut,
                HFin = heureFin,
                Duree = duree,
                GroupeId = editHoraireDto.GroupeId
            };
        }
    }
}
