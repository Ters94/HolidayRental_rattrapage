using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Rental.DAL.Entities
{
    public class MembreBienEchange
    {
        public int idMembre { get; set; }
        public int idBien { get; set; }
        public DateTime DateDebEchange { get; set; }
        public DateTime DateFinEchange { get; set; }
        public bool? Assurance { get; set; }
        public bool Valide { get; set; }
    }
}
