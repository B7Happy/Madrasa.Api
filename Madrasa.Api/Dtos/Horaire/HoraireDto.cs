namespace Madrasa.Api.Dtos.Horaire
{
    public class HoraireDto
    {
        public int Id { get; set; }
        public int NumJour { get; set; }
        public string Jour { get; set; }
        public TimeSpan HDeb { get; set; }
        public TimeSpan HFin { get; set; }
        public TimeSpan Duree { get; set; }
        public int GroupeId { get; set; }
    }
}
