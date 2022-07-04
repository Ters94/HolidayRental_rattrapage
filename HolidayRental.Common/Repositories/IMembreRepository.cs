using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayRental.Common.Repositories
{
    public interface IMembreRepository<TMembre> : IRepository<TMembre, int>
    {
        public int VerifPassword(string login, string password);
    }
}
