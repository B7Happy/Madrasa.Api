namespace Madrasa.Api.Model
{
    public class Professeurs
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? TelMobile { get; set; }
        public string? Email { get; set; }
        public List<Classes> Classes { get; set; }
        public Examen Examen { get; set; }

    }
}
