using Database.models;
using Database.requests;
using Microsoft.AspNetCore.Mvc;
using services;
using services.services;
using System.CodeDom;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectionController : ControllerBase
    {
        private readonly ElectionService _service;

        public ElectionController()
        {
            _service = new ElectionService();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateElection(CreateElectionRequest election)
        {
            var response = await _service.CreateElectionAsync(election);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<ApiResponse<List<Election>>>> GetAllElections()
        {
            var response = await _service.GetAllElectionsAsync();
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<ActionResult<ApiResponse<Election>>> GetElectionById(int electionID)
        {
            var response = await _service.GetElectionByIdAsync(electionID);
            return response.ToActionResult();
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateElection(Election election)
        {
            var response = await _service.UpdateElectionAsync(election);
            return response.ToActionResult();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteElection(int electionID)
        {
            var response = await _service.DeleteElectionAsync(electionID);
            return response.ToActionResult();
        }
    }
}
