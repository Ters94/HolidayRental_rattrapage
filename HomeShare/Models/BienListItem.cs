using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoliDayRental.Models
{
    public class BienListItem
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idBien { get; set; }

        [DisplayName("Titre")]
        public string titre { get; set; }

        [DisplayName("Info")]
        public string DescCourte { get; set; }

        [DisplayName("Nombre de personnes")]
        public int NombrePerson { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; }
        public Pays Pays { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }

    }
}