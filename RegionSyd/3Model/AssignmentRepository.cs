using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RegionSyd._3Model
{
    public class AssignmentRepository : IRepository<Assignment>
    {
        private readonly string _connectionString;

        //public AssignmentRepository(string connectionString)
        public AssignmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Assignment> GetAll()
        {
            var assignments = new List<Assignment>();
            string query = "SELECT * FROM ASSIGNMENT";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        assignments.Add(new Assignment
                        {
                            AssignmentId = (int)reader["AssignmentId"],
                            Number = (int)reader["Number"]
                        });
                    }
                }
            }

            return assignments;
        }

        public Assignment GetById(int id)
        {
            Assignment assignment = null;
            string query = "SELECT * FROM ASSIGNMENT WHERE AssignmentId = @AssignmentId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentId", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        assignment = new Assignment
                        {
                            AssignmentId = (int)reader["AssignmentId"],
                            Number = (int)reader["Number"]
                        };
                    }
                }
            }

            return assignment;
        }

        public void Add(Assignment assignment)
        {
            string query = "INSERT INTO ASSIGNMENT (Number) VALUES (@Number)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", assignment.Number);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Assignment assignment)
        {
            string query = "UPDATE ASSIGNMENT SET Number = @Number WHERE AssignmentId = @AssignmentId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", assignment.Number);
                command.Parameters.AddWithValue("@AssignmentId", assignment.AssignmentId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM ASSIGNMENT WHERE AssignmentId = @AssignmentId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentId", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
