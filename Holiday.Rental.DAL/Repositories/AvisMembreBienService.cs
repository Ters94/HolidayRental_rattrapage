using Holiday.Rental.DAL.Entities;
using Holiday.Rental.DAL.Repositories;
using HolidayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repositories
{

    public class AvisMembreService : ServiceBase, IAvisMembreBienRepository<AvisMembre>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [AvisMembreBien] WHERE [idAvis] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public AvisMembre Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AvisMembre> Get()
        {
            throw new NotImplementedException();
        }

        public int Insert(AvisMembre entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, AvisMembre entity)
        {
            throw new NotImplementedException();
        }
    }
}
