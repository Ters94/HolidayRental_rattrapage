using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Rental.DAL.Repositories
{
    public abstract class ServiceBase
    {
        protected string _connString = @"Data Source=LAPTOP-2B1BFEK4;Initial Catalog=HoliDayRental.DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
