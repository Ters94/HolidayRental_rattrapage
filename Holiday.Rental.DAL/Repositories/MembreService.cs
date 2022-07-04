using Holiday.Rental.DAL.Entities;
using Holiday.Rental.DAL.Handlers;
using Holiday.Rental.DAL.Repositories;
using HolidayRental.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HolidayRental.DAL.Repositories
{
    public class MembreService : ServiceBase, IMembreRepository<Membre>
    {
        public int VerifPassword(string login, string password)
        {
           
        
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idMembre] FROM [Membre] WHERE [Login] = @Login AND [Password] = @Password";
                    SqlParameter p_login = new SqlParameter() { ParameterName = "Login", Value = login };
                    SqlParameter p_password = new SqlParameter() { ParameterName = "Password", Value = password };
                    command.Parameters.Add(p_login);
                    command.Parameters.Add(p_password);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result is null) return -1;
                    return (int)result;
                }
            }
        }

        public Membre Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idMembre],[Nom],[Prenom],[Email],[Pays],[Telephone],[Login],[Password] WHERE [Membre] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToMembre(reader);
                    return null;
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Membre] WHERE [idMembre] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Membre> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idBien],[Nom],[Prenom],[Email],[Pays],[Telephone],[Login],[Password] FROM [Membre]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToMembre(reader);
                }
            }
        }

        public int Insert(Membre entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Membre]([Nom],[Prenom],[Email],[Pays],[Telephone],[Login],[Password]) OUTPUT [inserted].[idMembre] " +
                        "VALUES (@Nom,@Prenom,@Email,@Pays,@Telephone,@Login,@Password)";
                    SqlParameter p_Nom = new SqlParameter { ParameterName = "Nom", Value = entity.Nom };
                    SqlParameter p_Prenom = new SqlParameter { ParameterName = "Prenom", Value = entity.Prenom };
                    SqlParameter p_Email = new SqlParameter { ParameterName = "Email", Value = entity.Email };
                    SqlParameter p_Pays = new SqlParameter { ParameterName = "Pays", Value = entity.Pays };
                    SqlParameter p_Telephone = new SqlParameter { ParameterName = "Telephone", Value = entity.Telephone };
                    SqlParameter p_Login = new SqlParameter { ParameterName = "Login", Value = entity.Login };
                    SqlParameter p_Password = new SqlParameter { ParameterName = "Password", Value = entity.Password };

                    command.Parameters.Add(p_Nom);
                    command.Parameters.Add(p_Prenom);
                    command.Parameters.Add(p_Email);
                    command.Parameters.Add(p_Pays);
                    command.Parameters.Add(p_Telephone);
                    command.Parameters.Add(p_Login);
                    command.Parameters.Add(p_Password);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Membre entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Membre] SET [Nom] = @Nom, [Prenom] = @Prenom, [Email] = @Email, [Pays]=@Pays, [Telephone]=@Telephone, [Login]=@Login, [Password]=@Password " +
                        " WHERE [idMembre] = @id";
                    SqlParameter p_Nom = new SqlParameter { ParameterName = "Nom", Value = entity.Nom };
                    SqlParameter p_Prenom = new SqlParameter { ParameterName = "Prenom", Value = entity.Prenom };
                    SqlParameter p_Email = new SqlParameter { ParameterName = "Email", Value = entity.Email };
                    SqlParameter p_Pays = new SqlParameter { ParameterName = "Pays", Value = entity.Pays };
                    SqlParameter p_Telephone = new SqlParameter { ParameterName = "Telephone", Value = entity.Telephone };
                    SqlParameter p_Login = new SqlParameter { ParameterName = "Login", Value = entity.Login };
                    SqlParameter p_Password = new SqlParameter { ParameterName = "Password", Value = entity.Password };
                    SqlParameter p_id = new SqlParameter { ParameterName = "id", Value = entity.idMembre };

                    command.Parameters.Add(p_Nom);
                    command.Parameters.Add(p_Prenom);
                    command.Parameters.Add(p_Email);
                    command.Parameters.Add(p_Pays);
                    command.Parameters.Add(p_Telephone);
                    command.Parameters.Add(p_Login);
                    command.Parameters.Add(p_Password);
                    command.Parameters.Add(p_id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}