using Database.models;
using Microsoft.AspNetCore.Mvc;
using services;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectionController : ControllerBase
    {
        private readonly ElectionService _service;

        public ElectionController()
        {
            _service = new ElectionService();
        }

        [HttpPost]
        [Route("Elections/CreateElection")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateElection(Election election)
        {
            var response = await _service.CreateElectionAsync(election);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("Elections/GetAllElections")]
        public async Task<ActionResult<ApiResponse<List<Election>>>> GetAllElections()
        {
            var response = await _service.GetAllElectionsAsync();
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("Elections/GetElectionById")]
        public async Task<ActionResult<ApiResponse<Election>>> GetElectionById(int electionID)
        {
            var response = await _service.GetElectionByIdAsync(electionID);
            return response.ToActionResult();
        }

        [HttpPut]
        [Route("Elections/UpdateElection")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateElection(Election election)
        {
            var response = await _service.UpdateElectionAsync(election);
            return response.ToActionResult();
        }

        [HttpDelete]
        [Route("Elections/DeleteElection")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteElection(int electionID)
        {
            var response = await _service.DeleteElectionAsync(electionID);
            return response.ToActionResult();
        }
    }
}
