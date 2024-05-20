using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Dtos.Parent;

namespace Madrasa.Api.Dtos.Eleves
{
    public class CreateEleveRequestDto
    {
        public bool Suspendu { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Sexe { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? LieuNaissance { get; set; }
        public string? TelMobile { get; set; }
        public string? Email { get; set; }
        public int? MaisonId { get; set; }
        public int? ClassesId { get; set; }
    }

    public class CreateEleveRequest
    {
        public bool Suspendu { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Sexe { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? LieuNaissance { get; set; }
        public string? TelMobile { get; set; }
        public string? Email { get; set; }
        public int? MaisonId { get; set; }
        public int? ClassesId { get; set; }

        public CreateMaisonRequestDto Maison { get; set; }
        public List<CreateParentRequestDto> Parent { get; set; }
    }
}
