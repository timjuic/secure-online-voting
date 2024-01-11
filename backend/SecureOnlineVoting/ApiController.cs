
using Microsoft.AspNetCore.Mvc;

namespace SecureOnlineVoting
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("Users")]
        public ActionResult<string> ReturnUsername()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            // Combine the current directory and the database file name
            string databaseFileName = "database";
            string fullPath = Path.Combine(currentDirectory, databaseFileName);

            string connectionString = $"Data Source={fullPath}";

            DatabaseService dbHelper = new DatabaseService(connectionString);
            var users = dbHelper.GetUsers();
            
            return users[0].first_name;
        }
    }
}
