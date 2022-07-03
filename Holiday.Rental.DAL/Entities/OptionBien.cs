using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Rental.DAL.Entities
{
    public class OptionBien
    {
        public int idBien { get; set; }
        public int idOption { get; set; }
        public string Valeur { get; set; }
    }
}
