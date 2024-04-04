namespace Madrasa.Api.Model
{
    public class Classes
    {
        public int Id { get; set; }
        public string Classe { get; set; }
        public int ProfesseursId { get; set; }
        public Professeurs Professeurs { get; set; }
        public Examen Examen { get; set; }
        public int GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        public List<Eleves> Eleves { get; set; }
    }
}
