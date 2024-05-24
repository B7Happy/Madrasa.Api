using Madrasa.Api.Dtos.Professeurs;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class ProfesseursMappers
    {

        public static ProfesseursDto ToProfesseursDto(this Professeurs professeurs)
        {
            return new ProfesseursDto
            {
                Id = professeurs.Id,
                Nom = professeurs.Nom,
                TelMobile = professeurs.TelMobile,
                Email = professeurs.Email
            };
        }

        public static Professeurs ToProfesseursFromCreateDTO(this CreateProfesseursRequestDto createProfesseursRequestDto)
        {
            return new Professeurs
            {
                Id = createProfesseursRequestDto.Id,
                Nom = createProfesseursRequestDto.Nom,
                TelMobile = createProfesseursRequestDto.TelMobile,
                Email = createProfesseursRequestDto.Email
            };
        }

        public static Professeurs UpdateProfesseursRequestDtoToProfesseurs(UpdateProfesseursRequestDto updateProfesseursRequestDto)
        {
            return new Professeurs
            {
                Nom = updateProfesseursRequestDto.Nom,
                TelMobile = updateProfesseursRequestDto.TelMobile,
                Email = updateProfesseursRequestDto.Email
            };
        }
    }
}
