using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using RegionSyd._3Model;

namespace RegionSyd.Repositories
{
    public class DisponentRepository : IRepository<Disponent>
    {
        private readonly string _connectionString;

        public DisponentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool CheckId(string id)
        {
            try
            {
                Disponent disponent = null;
                string query = $"SELECT * FROM ASSIGNMENT WHERE DisponentID = {id}";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            disponent = new Disponent((string)reader["DisponentID"]);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Disponent> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Disponent entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Disponent entity)
        {
            throw new NotImplementedException();
        }
    }
}
