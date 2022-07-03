﻿using Holiday.Rental.DAL;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class BienDetails
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idBien { get; set; }

        [DisplayName("Titre")]
        public string titre { get; set; }

        [DisplayName("Info")]
        public string DescCourte { get; set; }

        [DisplayName("Description")]
        public string DescLong { get; set; }

        [DisplayName("Nombre de personnes")]
        public int NombrePerson { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; }
        public Pays Pays { get; set; }
        [DisplayName("Pays")]
        public string NomPays { get { return this.Pays.Libelle; } }

        [DisplayName("Ville")]
        public string Ville { get; set; }

        [DisplayName("Rue")]
        public string Rue { get; set; }

        [DisplayName("Numéro")]
        public string Numero { get; set; }

        [DisplayName("Code Postal")]
        public string CodePostal { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Assurance")]
        public bool AssuranceObligatoire { get; set; }

        [ScaffoldColumn(false)]
        public bool isEnabled { get; set; }

        [ScaffoldColumn(false)]
        [DataType("datetime-local")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}")]
        public DateTime? DisabledDate { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Latitude")]
        public string Latitude { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Longitude")]
        public string Longitude { get; set; }

        [ScaffoldColumn(false)]
        public int idMembre { get; set; }
    }
}