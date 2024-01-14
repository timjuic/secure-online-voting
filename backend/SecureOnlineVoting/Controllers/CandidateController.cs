using Database.models;
using Microsoft.AspNetCore.Mvc;
using services;
using services.services;
[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly CandidateService _service;

    public CandidateController()
    {
        _service = new CandidateService();
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<ApiResponse<Candidate>>> CreateCandidate(Candidate candidate)
    {
        ApiResponse<Candidate> response = await _service.CreateCandidateAsync(candidate);
        return response.ToActionResult();
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteCandidate(int candidateID)
    {
        ApiResponse<bool> response = await _service.DeleteCandidateAsync(candidateID);
        return response.ToActionResult();
    }

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateCandidate(Candidate candidate)
    {
        ApiResponse<bool> response = await _service.UpdateCandidateAsync(candidate);
        return response.ToActionResult();
    }

    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<ApiResponse<List<Candidate>>>> GetAllCandidates()
    {
        ApiResponse<List<Candidate>> response = await _service.GetAllCandidatesAsync();
        return response.ToActionResult();
    }

    [HttpGet]
    [Route("getbyid")]
    public async Task<ActionResult<ApiResponse<Candidate>>> GetCandidateById(int candidateID)
    {
        ApiResponse<Candidate> response = await _service.GetCandidateByIdAsync(candidateID);
        return response.ToActionResult();
    }

    [HttpGet]
    [Route("getbyelection")]
    public async Task<ActionResult<ApiResponse<List<Candidate>>>> GetCandidatesByElection(int electionID)
    {
        ApiResponse<List<Candidate>> response = await _service.GetCandidatesByElectionAsync(electionID);
        return response.ToActionResult();
    }
}