using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using RegionSyd._3Model;
using System.Windows.Markup;

namespace RegionSyd.Repositories
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
                        Func<TimeSpan, string> timeSpanToString = ts => ts.ToString(@"hh\:mm\:ss");
                        Func<DateTime, string> dateTimeToString = dt => dt.ToString(@"yyyy\-MM\-dd");
                        string disponentIDDelegator;
                        try //try catch to catch if a DisponentIDDelegator is NULL i databasen
                        {
                            disponentIDDelegator = (string)reader["DisponentIDDelegator"];
                        }
                        catch (Exception e) //burde være lavet med den fejlkode vi fik før 
                        {
                            disponentIDDelegator = "";     
                        }

                        assignments.Add(new Assignment
                        {
                            RegionalAssignmentID = (string)reader["RegionalAssignmentID"],
                            AssignmentType = (string)reader["AssignmentType"],
                            AssignmentDescription = (string)reader["AssignmentDescription"],
                            PatientName = (string)reader["PatientName"],
                            AppointmentTime = TimeOnly.Parse(timeSpanToString((TimeSpan)reader["AppointmentTime"])),
                            AppointmentDate = DateOnly.Parse(dateTimeToString((DateTime)reader["AppointmentDate"])),
                            StreetNameFrom = (string)reader["StreetNameFrom"],
                            StreetNumberFrom = (int)reader["StreetNumberFrom"],
                            ZipCodeFrom = (int)reader["ZipCodeFrom"],
                            StreetNameTo = (string)reader["StreetNameTo"],
                            StreetNumberTo = (int)reader["StreetNumberTo"],
                            ZipCodeTo = (int)reader["ZipCodeTo"],
                            DisponentIDDelegator = disponentIDDelegator,
                            DisponentIDCreator = (string)reader["DisponentIDCreator"],
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
                            ZipCodeFrom = (int)reader["ZipCodeFrom"],
                            ZipCodeTo = (int)reader["ZipCodeTo"],
                            DisponentIDDelegator = (string)reader["DisponentIDDelegator"],
                            DisponentIDCreator = (string)reader["DisponentIDCreator"],
                        };
                    }
                }
            }

            return assignment;
        }

        // add an assignment to the ASSIGNMENT table 
        public void Add(Assignment assignment)
        {
            string query = $"INSERT INTO ASSIGNMENT VALUES ({assignment.ToString()})";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
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

        public void Remove(Assignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}
