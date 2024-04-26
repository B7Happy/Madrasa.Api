using Madrasa.Api.Model;

namespace Madrasa.Api.Dtos.Classes
{
    public class ClassesDto
    {
        public int Id { get; set; }
        public string Classe { get; set; }
        public int ProfesseursId { get; set; }
        public int GroupeId { get; set; }
    }
}
