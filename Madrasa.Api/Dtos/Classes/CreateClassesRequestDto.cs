namespace Madrasa.Api.Dtos.Classes
{
    public class CreateClassesRequestDto
    {
        public string Classe { get; set; }
        public int ProfesseursId { get; set; }
        public int GroupeId { get; set; }
    }
}
