namespace Madrasa.Api.Model
{
    public class Matieres
    {
        public int ID { get; set; }
        public string Matiere { get; set; }
        public string Arabe { get; set; }
        public string? Traduction { get; set; }
        public bool Principale { get; set; }
    }
}
