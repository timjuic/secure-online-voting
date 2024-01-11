using Dapper;
using SecureOnlineVoting.Models;
using System.Data;
using System.Data.SQLite;

namespace SecureOnlineVoting
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<User> GetUsers()
        {
            using IDbConnection dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();

            string query = "SELECT * FROM users";
            List<User> users = dbConnection.Query<User>(query).AsList();

            return users;
        }
    }
}
