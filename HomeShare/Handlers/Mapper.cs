﻿using Holiday.Rental.DAL;
using HolidayRental.BLL.Entities;
using HoliDayRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Handlers
{
    public static class Mapper
    {
        public static BienListItem ToListItem(this BienEchangeBLL entity)
        {
            if (entity == null) return null;
            return new BienListItem
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                idPays = entity.Pays.idPays,
                NombrePerson = entity.NombrePerson,
                Photo = entity.Photo
            };
        }

        public static BienDetails ToDetails(this BienEchangeBLL entity)
        {
            if (entity == null) return null;
            return new BienDetails
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                DescLong = entity.DescLong,
                idPays = entity.Pays.idPays,
                NombrePerson = entity.NombrePerson,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                AssuranceObligatoire = entity.AssuranceObligatoire,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                idMembre = entity.Membre.idMembre
            };
        }
        public static Pays ToDetails(this PaysBLL entity)
        {
            if (entity == null) return null;
            return new Pays
            {
                idPays = entity.idPays,
                Libelle = entity.Libelle
            };
        }

        //public static MembreListItem ToListItem(this MembreBLL entity)
        //{
        //    if (entity == null) return null;
        //    return new MembreListItem
        //    {
        //        idMembre = entity.idMembre,
        //        Nom = entity.Nom,
        //        Prenom = entity.Prenom,
        //        Email = entity.Email,
        //        idPays = entity.Pays.idPays,
        //        Telephone = entity.Telephone
        //    };
        //}

        //public static MembreDetails ToDetails(this MembreBLL entity)
        //{
        //    if (entity == null) return null;
        //    return new MembreDetails
        //    {
        //        idMembre = entity.idMembre,
        //        Nom = entity.Nom,
        //        Prenom = entity.Prenom,
        //        Email = entity.Email,
        //        idPays = entity.Pays.idPays,
        //        Telephone = entity.Telephone,
        //        Login = entity.Login,
        //        Password = entity.Password
        //    };
        //}

        //public static MembreEdit ToEdit(this MembreBLL entity)
        //{
        //    if (entity == null) return null;
        //    return new MembreEdit
        //    {
        //        Nom = entity.Nom,
        //        Prenom = entity.Prenom,
        //        Email = entity.Email,
        //        idPays = entity.Pays.idPays,
        //        Telephone = entity.Telephone,
        //        Login = entity.Login,
        //        Password = entity.Password
        //    };
        //}

        //public static MembreDelete ToDelete(this MembreBLL entity)
        //{
        //    if (entity == null) return null;
        //    return new MembreDelete
        //    {
        //        Nom = entity.Nom,
        //        Prenom = entity.Prenom,
        //        Login = entity.Login
        //    };
        //}
    }
}

