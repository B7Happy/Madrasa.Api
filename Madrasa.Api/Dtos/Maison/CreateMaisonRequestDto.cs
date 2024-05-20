
namespace Madrasa.Api.Dtos.Maison
{
    public class CreateMaisonRequestDto
    {
        public string? Adresse { get; set; }
        public string? Complement { get; set; }
        public int? CodePostal { get; set; }
        public string? Ville { get; set; }
        public int? TelDomicile { get; set; }
        public bool? Adherent { get; set; }
        public string? Categorie { get; set; }

    }
}
