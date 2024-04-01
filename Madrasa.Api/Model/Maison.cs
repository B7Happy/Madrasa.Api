using System.ComponentModel.DataAnnotations.Schema;

namespace Madrasa.Api.Model
{
    public class Maison
    {
        public int Id { get; set; }
        public string? Adresse { get; set; }
        public string? Complement { get; set; }
        public int? CodePostal { get; set; }
        public string? Ville { get; set; }
        public int? TelDomicile { get; set; }
        public bool? Adherent { get; set; }
        public string? Categorie { get; set; }
        public List<Eleves> Eleves { get; set; }
        public List<Parent> Parent { get; set; }
    }
}
