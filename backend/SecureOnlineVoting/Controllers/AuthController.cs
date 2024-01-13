using Database.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using services;
using services.services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService;

    public AuthController(IConfiguration configuration)
    {
        _authService = new AuthService();
        _configuration = configuration;
    }

    //[HttpPost("login")]
    //public async IActionResult Login([FromBody] String model)
    //{
    //    //// Validate user credentials (replace with your authentication logic)
    //    //if (IsValidUser(model.Username, model.Password))
    //    //{
    //    //    // Generate JWT token
    //    //    var token = JwtHelper.GenerateToken(model.Username, _configuration);
    //    //    return Ok(new { Token = token });
    //    //}

    //    //return Unauthorized(new { Message = "Invalid credentials" });
    //}

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<ApiResponse<bool>>> Register([FromBody] Voter newVoter)
    {
        ApiResponse<bool> response = await _authService.RegisterUserAsync(newVoter);
        return response.ToActionResult();
    }
}