using Database.models;
using Database.requests;
using Database.responses;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<LoginResponseData>>> Login([FromBody] LoginRequest loginData)
    {
        ApiResponse<LoginResponseData> response = await _authService.LoginUserAsync(loginData, _configuration);
        return response.ToActionResult();
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<ApiResponse<bool>>> Register([FromBody] Voter newVoter)
    {
        ApiResponse<bool> response = await _authService.RegisterUserAsync(newVoter);
        return response.ToActionResult();
    }
}