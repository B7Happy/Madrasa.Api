using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Model
{
    public class Examen
    {
        public int Id { get; set; }
        public string? AnneeScolaire { get; set; }
        public string? Semestre { get; set; }
        public int? ClassesId { get; set; }
        public Classes? Classes { get; set; }
        public int? ProfesseursId { get; set; }
        public Professeurs? Professeurs { get; set; }
        public int MatiereID { get; set; }
        public int? MP { get; set; }
        public int? MPB { get; set; }
        public string? MS1Text  { get; set; }
        public int? MS1Note { get; set; }
        public string? MS2Text { get; set; }
        public int? MS2Note { get; set; }
        public string? MS3Text { get; set; }
        public int? MS3Note { get; set; }
        public string? MS4Text { get; set; }
        public int? MS4Note { get; set; }
        public string? MS5Text { get; set; }
        public int? MS5Note { get; set; }
        public string? MS6Text { get; set; }
        public int? MS6Note { get; set; }
        public string? MS7Text { get; set; }
        public int? MS7Note { get; set; }
        public int? Akhlaq { get; set; }
        public int? Hudhur { get; set; }
        public int? Total { get; set; }
        public bool? Actif { get; set; }

    }
}
