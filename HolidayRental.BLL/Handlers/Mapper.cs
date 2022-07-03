using Holiday.Rental.DAL;
using Holiday.Rental.DAL.Entities;
using HolidayRental.BLL.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.BLL.Handlers
{
    public static class Mapper
    {
        public static MembreBLL ToBLL(this Membre entity)
        {
            if (entity == null) return null;
            return new MembreBLL(
                entity.idMembre,
                entity.Nom,
                entity.Prenom,
                entity.Email,
                entity.Pays,
                entity.Telephone,
                entity.Login,
                entity.Password);
        }

        public static Membre ToDAL(this MembreBLL entity)
        {
            if (entity == null) return null;
            return new Membre
            {
                idMembre = entity.idMembre,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Pays = entity.idPays,
                Telephone = entity.Telephone,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        public static BienEchangeBLL ToBLL(this BienEchange entity)
        {
            if (entity == null) return null;
            return new BienEchangeBLL(
                entity.idBien,
                entity.titre,
                entity.DescCourte,
                entity.DescLong,
                entity.NombrePerson,
                entity.Pays,
                entity.Ville,
                entity.Rue,
                entity.Numero,
                entity.CodePostal,
                entity.Photo,
                entity.AssuranceObligatoire,
                entity.Latitude,
                entity.Longitude,
                entity.idMembre
                );
        }

        public static BienEchange ToDAL(this BienEchangeBLL entity)
        {
            if (entity == null) return null;
            return new BienEchange
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                DescLong = entity.DescLong,
                Pays = entity.PaysId,
                NombrePerson = entity.NombrePerson,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                AssuranceObligatoire = entity.AssuranceObligatoire,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                idMembre = entity.MembreId
            };
        }

        public static PaysBLL ToBLL(this Pays entity)
        {
            if (entity == null) return null;
            return new PaysBLL(
                entity.idPays,
                entity.Libelle);
        }

        public static Pays ToDAL(this PaysBLL entity)
        {
            if (entity == null) return null;
            return new Pays
            {
                idPays = entity.idPays,
                Libelle = entity.Libelle
            };
        }
    }
}
