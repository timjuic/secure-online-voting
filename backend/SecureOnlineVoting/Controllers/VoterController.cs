using Database.models;
using Microsoft.AspNetCore.Mvc;
using services;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoterController : ControllerBase
    {
        private readonly VoterService _service;

        public VoterController()
        {
            _service = new VoterService();
        }

        [HttpPost]
        [Route("Voters/CreateVoter")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateVoter(Voter voter)
        {
            var response = await _service.CreateVoterAsync(voter);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("Voters/GetAllVoters")]
        public async Task<ActionResult<ApiResponse<List<Voter>>>> GetAllVoters()
        {
            var response = await _service.GetAllVotersAsync();
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("Voters/GetVoterById")]
        public async Task<ActionResult<ApiResponse<Voter>>> GetVoterById(int votersID)
        {
            var response = await _service.GetVoterByIdAsync(votersID);
            return response.ToActionResult();
        }

        [HttpPut]
        [Route("Voters/UpdateVoter")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateVoter(Voter voter)
        {
            var response = await _service.UpdateVoterAsync(voter);
            return response.ToActionResult();
        }

        [HttpDelete]
        [Route("Voters/DeleteVoter")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteVoter(int votersID)
        {
            var response = await _service.DeleteVoterAsync(votersID);
            return response.ToActionResult();
        }
    }

}
