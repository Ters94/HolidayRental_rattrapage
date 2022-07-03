using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.BLL.Entities
{
    public class PaysBLL
    {
        public int idPays { get; set; }
        public string Libelle { get; set; }

        

        public PaysBLL(int id, string libelle)
        {
            idPays = id;
            Libelle = libelle;
        }
    }
}
