namespace Madrasa.Api.Dtos.Professeurs
{
    public class UpdateProfesseursRequestDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? TelMobile { get; set; }
        public string? Email { get; set; }
    }
}
