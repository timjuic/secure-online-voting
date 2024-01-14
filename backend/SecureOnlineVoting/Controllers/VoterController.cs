using Database.models;
using Microsoft.AspNetCore.Mvc;
using services;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoterController : ControllerBase
    {
        private readonly VoterService _service;

        public VoterController()
        {
            _service = new VoterService();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateVoter(Voter voter)
        {
            var response = await _service.CreateVoterAsync(voter);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<ApiResponse<List<Voter>>>> GetAllVoters()
        {
            var response = await _service.GetAllVotersAsync();
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<ActionResult<ApiResponse<Voter>>> GetVoterById(int votersID)
        {
            var response = await _service.GetVoterByIdAsync(votersID);
            return response.ToActionResult();
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateVoter(Voter voter)
        {
            var response = await _service.UpdateVoterAsync(voter);
            return response.ToActionResult();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteVoter(int votersID)
        {
            var response = await _service.DeleteVoterAsync(votersID);
            return response.ToActionResult();
        }
    }

}
