namespace Madrasa.Api.Dtos.Classes
{
    public class UpdateClassesRequestDto
    {
        public int Id { get; set; }
        public string Classe { get; set; }
        public int ProfesseursId { get; set; }
        public int GroupeId { get; set; }
    }
}
