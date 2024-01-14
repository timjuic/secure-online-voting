using Database.models;
using Microsoft.AspNetCore.Mvc;
using services;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        VoteService _service = new VoteService();

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ApiResponse<Vote>>> CreateVote(Vote vote)
        {
            ApiResponse<Vote> response = await _service.CreateVoteAsync(vote);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<ApiResponse<List<Vote>>>> GetAllVotes()
        {
            ApiResponse<List<Vote>> response = await _service.GetAllVotesAsync();
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<ActionResult<ApiResponse<Vote>>> GetVoteById(int voteID)
        {
            ApiResponse<Vote> response = await _service.GetVoteByIdAsync(voteID);
            return response.ToActionResult();
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteVote(int voteID)
        {
            ApiResponse<bool> response = await _service.DeleteVoteAsync(voteID);
            return response.ToActionResult();
        }
    }
}
