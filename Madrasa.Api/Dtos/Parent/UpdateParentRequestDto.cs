namespace Madrasa.Api.Dtos.Parent
{
    public class UpdateParentRequestDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int? TelMobile { get; set; }
        public string? Email { get; set; }
    }
}
