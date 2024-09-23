using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

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

        // get all assignments in the ASSIGNMENT table 
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
                            RegionalAssignmentID = (string)reader["RegionalAssignmentID"],
                            AssignmentType = (string)reader["AssignmentType"],
                            AssignmentDescription = (string)reader["AssignmentDescription"],
                            PatientName = (string)reader["PatientName"],
                            AppointmentTime = (TimeOnly)reader["AppointmentTime"],
                            AppointmentDate = (DateOnly)reader["AppointmentDate"],
                            AddressFrom = (string)reader["AddressFrom"],
                            AddressTo = (string)reader["AddressTo"],
                            DisponentDelegator = (int)reader["DisponentDelegator"],
                            DisponentCreator = (int)reader["DisponentCreator"],
                            RegionID = (int)reader["RegionID"],
                        });
                    }
                }
            }

            return assignments;
        }

        // get the assigntent with the chosen assignmentID from the ASSIGNMENT table
        public Assignment GetById(int id)
        {
            Assignment assignment = null;
            string query = "SELECT * FROM ASSIGNMENT WHERE RegionalAssignmentID = @RegionalAssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegionalAssignmentID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        assignment = new Assignment
                        {
                            RegionalAssignmentID = (string)reader["RegionalAssignmentID"],
                            AssignmentType = (string)reader["AssignmentType"],
                            AssignmentDescription = (string)reader["AssignmentDescription"],
                            PatientName = (string)reader["PatientName"],
                            AppointmentTime = (TimeOnly)reader["AppointmentTime"],
                            AppointmentDate = (DateOnly)reader["AppointmentDate"],
                            AddressFrom = (string)reader["AddressFrom"],
                            AddressTo = (string)reader["AddressTo"],
                            DisponentDelegator = (int)reader["DisponentDelegator"],
                            DisponentCreator = (int)reader["DisponentCreator"],
                            RegionID = (int)reader["RegionID"],
                        };
                    }
                }
            }

            return assignment;
        }

        // add an assignment to the ASSIGNMENT table 
        public void Add(Assignment assignment)
        {
            string query = "INSERT INTO ASSIGNMENT VALUES (@AssignmentToString)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentToString", assignment.ToString());
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Updates an assignment in the ASSIGNMENT table chosen by the RegionalAssignmentID
        public void Update(Assignment assignment)
        {
            string query = "UPDATE ASSIGNMENT SET @AssignmentToUpdate WHERE RegionalAssignmentID = @RegionalAssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentToUpdate", assignment.ToUpdate());
                command.Parameters.AddWithValue("@RegionalAssignmentID", assignment.RegionalAssignmentID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Delete an assignment in the ASSIGNMENT table chosen by the RegionalAssignmentID
        public void Delete(int ID)
        {
            string query = "DELETE FROM ASSIGNMENT WHERE RegionalAssignmentID = @RegionalAssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegionalAssignmentID", ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
