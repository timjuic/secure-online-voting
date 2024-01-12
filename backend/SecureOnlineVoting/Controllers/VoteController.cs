using Database.models;
using Microsoft.AspNetCore.Mvc;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        VoteService service = new VoteService();

        [HttpPost]
        [Route("Votes/CreateVote")]
        public ActionResult<bool> CreateVoter(Vote vote)
        {
            var response = service.CreateVoteAsync(vote);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("Votes/GetAllVotes")]
        public async Task<ActionResult<List<Vote>>> GetAllVotes()
        {
            var response = await service.GetAllVotesAsync();
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return null;
        }

        [HttpGet]
        [Route("Votes/GetVoteById")]
        public async Task<ActionResult<List<Vote>>> GetVoteById(int voteID)
        {
            var response = service.GetVoteByIdAsync(voteID);
            if (response is not null)
            {
                return Ok(response);
            }
            return null;
        }

        [HttpPut]
        [Route("Votes/UpdateVote")]
        public ActionResult<bool> UpdateVote(Vote vote)
        {
            var response = service.UpdateVoteAsync(vote);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpDelete]
        [Route("Votes/DeleteVote")]
        public ActionResult<bool> DeleteVote(int voteID)
        {
            var response = service.DeleteVoteAsync(voteID);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }
    }
}
