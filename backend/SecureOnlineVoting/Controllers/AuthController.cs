using Database.models;
using Microsoft.AspNetCore.Mvc;
using services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Validate user credentials (replace with your authentication logic)
        if (IsValidUser(model.Username, model.Password))
        {
            // Generate JWT token
            var token = JwtHelper.GenerateToken(model.Username, _configuration);
            return Ok(new { Token = token });
        }

        return Unauthorized(new { Message = "Invalid credentials" });
    }

    [HttpPost("register")]
    public Task<ActionResult<ApiResponse<Voter>>> Register([FromBody] Voter newVoter)
    {
        var token = JwtHelper.GenerateToken(model.Username, _configuration);
        return Ok(new { Token = token });
    }

    // Replace this with your actual authentication logic
    private bool IsValidUser(string username, string password)
    {
        // Replace this with your actual authentication logic
        return username == "demo" && password == "demo123";
    }
}