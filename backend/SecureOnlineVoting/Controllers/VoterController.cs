using Database.models;
using Microsoft.AspNetCore.Mvc;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoterController : ControllerBase
    {
        VoterService service = new VoterService();

        [HttpPost]
        [Route("Voters/CreateVoter")]
        public ActionResult<bool> CreateVoter(Voter voter)
        {
            var response = service.CreateVoterAsync(voter);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("Voters/GetAllVoters")]
        public async Task<ActionResult<List<Voter>>> GetAllVoters()
        {
            var response = await service.GetAllVotersAsync();
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return null;
        }

        [HttpGet]
        [Route("Voters/GetVoterById")]
        public async Task<ActionResult<Voter>> GetVoterById(int votersID)
        {
            var response = await service.GetVoterByIdAsync(votersID);
            if (response is not null)
            {
                return Ok(response);
            }
            return null;
        }

        [HttpPut]
        [Route("Voters/UpdateVoter")]
        public ActionResult<bool> UpdateVoter(Voter voter)
        {
            var response = service.UpdateVoterAsync(voter);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpDelete]
        [Route("Voters/DeleteVoter")]
        public ActionResult<bool> DeleteVoter(int votersID)
        {
            var response = service.DeleteVoterAsync(votersID);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

    }
}
