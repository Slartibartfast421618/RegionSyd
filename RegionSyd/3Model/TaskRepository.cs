using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd._3Model
{
public class TaskRepository : IRepository<Task>
{
    private readonly string _connectionString;

    //public TaskRepository(string connectionString)
    public TaskRepository(IConfiguration configuration)
    {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IEnumerable<Task> GetAll()
    {
        var tasks = new List<Task>();
        string query = "SELECT * FROM TASK";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tasks.Add(new Task
                    {
                        TaskId = (int)reader["TaskId"],
                        Number = (int)reader["Number"]
                    });
                }
            }
        }

        return tasks;
    }

    public Task GetById(int id)
    {
        Task task = null;
        string query = "SELECT * FROM TASK WHERE TaskId = @TaskId";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TaskId", id);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    task = new Task
                    {
                        TaskId = (int)reader["TaskId"],
                        Number = (int)reader["Number"]
                    };
                }
            }
        }

        return task;
    }

    public void Add(Task task)
    {
        string query = "INSERT INTO TASK (Number) VALUES (@Number)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Number", task.Number);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void Update(Task task)
    {
        string query = "UPDATE TASK SET Number = @Number WHERE TaskId = @TaskId";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Number", task.Number);
            command.Parameters.AddWithValue("@TaskId", task.TaskId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string query = "DELETE FROM TASK WHERE TaskId = @TaskId";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TaskId", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
}
