using System.ComponentModel.DataAnnotations.Schema;

namespace Madrasa.Api.Model
{
    public class Bulletin
    {
        public int Id { get; set; }
        public int? ElevesId { get; set; }
        public Eleves? Eleves { get; set; }
        public int? ExamenId { get; set; }
        public Examen? Examen { get; set; }
        public int? Mention { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MP { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS1 { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS2 { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS3 { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS4 { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS5 { get; set; }
       
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS6 { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MS7 { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Akhlaq { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Hudhur { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Total { get; set; }
    }
}
