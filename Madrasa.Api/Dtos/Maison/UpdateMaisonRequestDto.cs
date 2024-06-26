﻿using Madrasa.Api.Model;

namespace Madrasa.Api.Dtos.Maison
{
    public class UpdateMaisonRequestDto
    {
        public int Id { get; set; }
        public string? Adresse { get; set; }
        public string? Complement { get; set; }
        public int? CodePostal { get; set; }
        public string? Ville { get; set; }
        public int? TelDomicile { get; set; }
        public bool? Adherent { get; set; }
        public string? Categorie { get; set; }
    }
}
