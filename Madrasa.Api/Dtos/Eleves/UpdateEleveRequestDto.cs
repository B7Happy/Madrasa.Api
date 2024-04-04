namespace Madrasa.Api.Dtos.Eleves
{
    public class UpdateEleveRequestDto
    {
        public int Id { get; set; }
        public int SN { get; set; }
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
        public DateTime DateEntree { get; set; }
    }
}