using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Rental.DAL.Entities
{
    public class Membre
    {
        public int idMembre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Pays { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
