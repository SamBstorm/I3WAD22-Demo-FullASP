using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    class ClientService
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
            return null;
        }

        public int Insert(Client entity)
        {
            return 0;
        }

        public bool Update(int id, Client entity)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }
    }
}
