using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class ClientService
    {
        private string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";
        public IEnumerable<Client> Get()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idClient], [nom], [prenom], [email], [adresse] FROM [Client]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToClient();
                        }
                    }
                }
            }
        }

        public Client Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idClient], [nom], [prenom], [email], [adresse] FROM [Client] WHERE [idClient] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToClient();
                        return null;

                        //Format ternaire : return (reader.Read()) ? reader.ToClient() : null;
                    }
                }
            }
        }

        public int Insert(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    /*command.CommandText = @"INSERT INTO [Client] ([nom], [prenom], [email], [pass], [adresse])
                                            OUTPUT [inserted].[idClient]
                                            VALUES (@nom, @prenom, @email, HASHBYTES('SHA2_512',@pass), @adresse)";*/
                    command.CommandText = "SP_ClientAdd";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("prenom", entity.prenom);
                    command.Parameters.AddWithValue("email", entity.email);
                    command.Parameters.AddWithValue("pass", entity.pass);
                    command.Parameters.AddWithValue("adresse", (object) entity.adresse ?? DBNull.Value);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Client entity)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [Client]
                                            SET [nom] = @nom,
                                                [prenom] = @prenom,
                                                [email] = @email,
                                                [adresse] = @adresse
                                            WHERE [idClient] = @id";
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("prenom", entity.prenom);
                    command.Parameters.AddWithValue("email", entity.email);
                    command.Parameters.AddWithValue("adresse", (object)entity.adresse ?? DBNull.Value);
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Client] WHERE [idClient] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
