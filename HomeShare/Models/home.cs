using Holiday.Rental.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class home
    {
        public IEnumerable<BienListItem> BiensEchanges { get; set; }
        public IEnumerable<Pays> ListPays { get; set; }
        public IEnumerable<MembreDetails> Membres { get; set; }
        public LoginForm Connection { get; set; }
        public MembreCreate CreationMembre { get; set; }

    }
}
