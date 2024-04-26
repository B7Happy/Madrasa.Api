using System.ComponentModel.DataAnnotations.Schema;

namespace Madrasa.Api.Model
{
    public class Eleves
    {
        private DateTime? _dateDeNaissance;

        public int Id { get; set; }
        public int SN { get; set; }
        public bool Suspendu { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Sexe { get; set; }
        public DateTime? DateNaissance
        {
            get { return _dateDeNaissance; }
            set { _dateDeNaissance = value; }
        }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (_dateDeNaissance.HasValue)
                {
                    return CalculerAge(_dateDeNaissance.Value, DateTime.Now);
                }
                else
                {
                    return null;
                }
            }
        }
        public string? LieuNaissance { get; set; }
        public string? TelMobile { get; set; }
        public string? Email { get; set; }
        public int? MaisonId { get; set; }
        public Maison? Maison { get; set; }
        public int? ClassesId { get; set; }
        public Classes? Classes { get; set; }
        public DateTime DateEntree { get; set; }

        private int? CalculerAge(DateTime dateDeNaissance, DateTime dateActuelle)
        {
            int age = dateActuelle.Year - dateDeNaissance.Year;

            // Vérification si l'anniversaire est déjà passé cette année
            if (dateActuelle.Month < dateDeNaissance.Month || (dateActuelle.Month == dateDeNaissance.Month && dateActuelle.Day < dateDeNaissance.Day))
            {
                age--;
            }

            return age;
        }
    }
}
