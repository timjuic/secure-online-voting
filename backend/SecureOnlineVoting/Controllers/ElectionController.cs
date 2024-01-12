using Database.models;
using Microsoft.AspNetCore.Mvc;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElectionController : ControllerBase
    {
        ElectionService service = new ElectionService();

        [HttpPost]
        [Route("Elections/CreateElection")]
        public ActionResult<bool> CreateElection(Election election)
        {
            var response = service.CreateElectionAsync(election);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("Elections/GetAllElections")]
        public async Task<ActionResult<List<Election>>> GetAllElections()
        {
            var response = await service.GetAllElectionsAsync();
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return null;
        }

        [HttpGet]
        [Route("Elections/GetElectionById")]
        public async Task<ActionResult<Election>> GetElectionById(int electionID)
        {
            var response = await service.GetElectionByIdAsync(electionID);
            if (response is not null)
            {
                return Ok(response);
            }
            return null;
        }

        [HttpPut]
        [Route("Elections/UpdateElection")]
        public ActionResult<bool> UpdateElection(Election election)
        {
            var response = service.UpdateElectionAsync(election);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpDelete]
        [Route("Elections/DeleteElection")]
        public ActionResult<bool> DeleteElection(int electionID)
        {
            var response = service.DeleteElectionAsync(electionID);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }
    }
}
