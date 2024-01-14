using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string databaseFilePath = "database.sqlite";
        string scriptFilePath = "db-script.sql";

        string connectionString = $"Data Source={databaseFilePath};Version=3;";

        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string script;
                using (StreamReader reader = new StreamReader(scriptFilePath))
                {
                    script = reader.ReadToEnd();
                }

                using (SQLiteCommand command = new SQLiteCommand(script, connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Database and tables created successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}