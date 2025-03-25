using Microsoft.Data.SqlClient;

namespace CheckboxDemo.Models
{

    public class Signup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool SignupToNewsLetter { get; set; }
    }
    public class SignupDb
    {
        private string _connectionString;

        public SignupDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Signup signup)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Signups (Name, Age, SignupToNewsLetter) " +
                "VALUES (@name, @age, @signup)";
            cmd.Parameters.AddWithValue("@name", signup.Name);
            cmd.Parameters.AddWithValue("@age", signup.Age);
            cmd.Parameters.AddWithValue("@signup", signup.SignupToNewsLetter);
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
