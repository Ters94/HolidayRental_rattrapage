using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.BLL.Entities
{
    public class BienEchangeBLL
    {
        public int idBien { get; set; }
        public string titre { get; set; }
        public string DescCourte { get; set; }
        public string DescLong { get; set; }
        public int NombrePerson { get; set; }
        public PaysBLL Pays { get; set; }
        public int PaysId { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string CodePostal { get; set; }
        public string Photo { get; set; }
        public bool AssuranceObligatoire { get; set; }
        public bool isEnabled { get; set; }
        public DateTime? DisabledDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public MembreBLL Membre { get; set; }
        public int MembreId { get; set; }
        public DateTime DateCreation { get; set; }

        public BienEchangeBLL(int id, string Titre, string descCourte, string descLong, int nbrePerson, PaysBLL pays, string ville, string rue, string num, string cP, string photo, bool assurance, string lat, string longitude, MembreBLL membre)
        {
            idBien = id;
            titre = Titre;
            DescCourte = descCourte;
            DescLong = descLong;
            NombrePerson = nbrePerson;
            Pays = pays;
            if (pays == null) throw new ArgumentNullException(nameof(PaysId));
            PaysId = pays.idPays;
            Ville = ville;
            Rue = rue;
            Numero = num;
            CodePostal = cP;
            Photo = photo;
            AssuranceObligatoire = assurance;
            Latitude = lat;
            Longitude = longitude;
            Membre = membre;
            if (membre == null) throw new ArgumentNullException(nameof(MembreId));
            MembreId = membre.idMembre;
        }

        public BienEchangeBLL(int id, string Titre, string descCourte, string descLong, int nbrePerson, int paysID, string ville, string rue, string num, string codeP, string photo, bool assurance, string lat, string longitude, int membreID)
        {
            idBien = id;
            titre = Titre;
            DescCourte = descCourte;
            DescLong = descLong;
            NombrePerson = nbrePerson;
            PaysId = paysID;
            Ville = ville;
            Rue = rue;
            Numero = num;
            CodePostal = codeP;
            Photo = photo;
            AssuranceObligatoire = assurance;
            Latitude = lat;
            Longitude = longitude;
            MembreId = membreID;
        }
    }
}
