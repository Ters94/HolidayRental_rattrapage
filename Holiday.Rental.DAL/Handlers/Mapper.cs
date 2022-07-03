using Holiday.Rental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Holiday.Rental.DAL.Handlers
{
    public static class Mapper
    {
        public static AvisMembre ToAvisMembreBien(IDataRecord record)
        {
            if (record is null) return null;
            return new AvisMembre
            {
                idAvis = (int)record[nameof(AvisMembre.idAvis)],
                note = (int)record[nameof(AvisMembre.note)],
                message = (string)record[nameof(AvisMembre.message)],
                idMembre = (int)record[nameof(AvisMembre.idMembre)],
                idBien = (int)record[nameof(AvisMembre.idBien)],
                DateAvis = (DateTime)record[nameof(AvisMembre.DateAvis)],
                Approuve = (bool)record[nameof(AvisMembre.Approuve)]
            };
        }

        public static BienEchange ToBienEchange(IDataRecord record)
        {
            if (record is null) return null;
            return new BienEchange
            {
                idBien = (int)record[nameof(BienEchange.idBien)],
                titre = (string)record[nameof(BienEchange.titre)],
                DescCourte = (string)record[nameof(BienEchange.DescCourte)],
                DescLong = (string)record[nameof(BienEchange.DescLong)],
                NombrePerson = (int)record[nameof(BienEchange.NombrePerson)],
                Pays = (int)record[nameof(BienEchange.Pays)],
                Ville = (string)record[nameof(BienEchange.Ville)],
                Rue = (string)record[nameof(BienEchange.Rue)],
                Numero = (string)record[nameof(BienEchange.Numero)],
                CodePostal = (string)record[nameof(BienEchange.CodePostal)],
                Photo = (string)record[nameof(BienEchange.Photo)],
                AssuranceObligatoire = (bool)record[nameof(BienEchange.AssuranceObligatoire)],
                isEnabled = (bool)record[nameof(BienEchange.isEnabled)],
                DisabledDate = (record[nameof(BienEchange.DisabledDate)] is DBNull) ? null : (DateTime?)record[nameof(BienEchange.DisabledDate)],
                Latitude = (string)record[nameof(BienEchange.Latitude)],
                Longitude = (string)record[nameof(BienEchange.Longitude)],
                idMembre = (int)record[nameof(BienEchange.idMembre)],
                DateCreation = (DateTime)record[nameof(BienEchange.DateCreation)]
            };
        }

        public static MembreBienEchange ToMembreBienEchange(IDataRecord record)
        {
            if (record is null) return null;
            return new MembreBienEchange
            {
                idMembre = (int)record[nameof(MembreBienEchange.idMembre)],
                idBien = (int)record[nameof(MembreBienEchange.idBien)],
                DateDebEchange = (DateTime)record[nameof(MembreBienEchange.DateDebEchange)],
                DateFinEchange = (DateTime)record[nameof(MembreBienEchange.DateFinEchange)],
                Assurance = (record[nameof(MembreBienEchange.Assurance)] is DBNull) ? null : (bool?)record[nameof(MembreBienEchange.Assurance)],
                Valide = (bool)record[nameof(MembreBienEchange.Valide)]
            };
        }

        public static Membre ToMembre(IDataRecord record)
        {
            if (record is null) return null;
            return new Membre
            {
                idMembre = (int)record[nameof(Membre.idMembre)],
                Nom = (string)record[nameof(Membre.Nom)],
                Prenom = (string)record[nameof(Membre.Prenom)],
                Email = (string)record[nameof(Membre.Email)],
                Pays = (int)record[nameof(Membre.Pays)],
                Telephone = (string)record[nameof(Membre.Telephone)],
                Login = (string)record[nameof(Membre.Login)],
                Password = (string)record[nameof(Membre.Password)]
            };
        }

        public static OptionBien ToOptionsBien(IDataRecord record)
        {
            if (record is null) return null;
            return new OptionBien
           {
                idBien = (int)record[nameof(OptionBien.idBien)],
                idOption = (int)record[nameof(OptionBien.idOption)],
                Valeur = (string)record[nameof(OptionBien.Valeur)]
            };
        }

        public static Options ToOptions(IDataRecord record)
        {
            if (record is null) return null;
            return new Options
            {
                idOption = (int)record[nameof(Options.idOption)],
                Libelle = (string)record[nameof(Options.Libelle)]
            };
        }

        public static Pays ToPays(IDataRecord record)
        {
            if (record is null) return null;
            return new Pays
            {
                idPays = (int)record[nameof(Pays.idPays)],
                Libelle = (string)record[nameof(Pays.Libelle)]
            };
        }
    }
}

    }
}
