namespace Madrasa.Api.Dtos.Horaire
{
    public class CreateHoraireDto
    {
        public int NumJour { get; set; }
        public string Jour { get; set; }
        public string HDeb { get; set; }
        public string HFin { get; set; }
        public string Duree { get; set; }
        public int GroupeId { get; set; }
    }
}
