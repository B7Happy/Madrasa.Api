namespace Madrasa.Api.Model
{
    public class Parent
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int? TelMobile { get; set; }
        public string? Email { get; set; }
        public int? MaisonId { get; set; }
        public Maison? Maison { get; set; }

    }
}
