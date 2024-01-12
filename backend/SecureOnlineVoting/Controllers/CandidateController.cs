using Database.models;
using Microsoft.AspNetCore.Mvc;
using services.services;

namespace SecureOnlineVoting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        CandidateService service = new CandidateService();

        [HttpPost]
        [Route("Candidates/CreateCandidate")]
        public ActionResult<bool> CreateCandidate(Candidate candidate)
        {
            var response = service.CreateCandidateAsync(candidate);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpDelete]
        [Route("Candidates/DeleteCandidate")]
        public ActionResult<bool> DeleteCandidate(int candidateID)
        {
            var response = service.DeleteCandidateAsync(candidateID);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        [Route("Candidates/UpdateCandidate")]
        public ActionResult<bool> Updatecandidate(Candidate candidate)
        {
            var response = service.UpdateCandidateAsync(candidate);
            if (response.IsCanceled == true)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        [Route("Candidates/GetAllCandidates")]
        public async Task<ActionResult<List<Candidate>>> GetAllCandidates()
        {
            var response = await service.GetAllCandidatesAsync();
            if (response.Count > 0)
            {
                return Ok(response);
            }
           
            return null;
        }

        [HttpGet]
        [Route("Candidates/GetCandidateById")]
        public async Task<ActionResult<Candidate>> GetCandidateById(int candidateID)
        {
            var response = await service.GetCandidateByIdAsync(candidateID);
            if (response is not null)
            {
                return Ok(response);
            }

            return null;
        }

        [HttpGet]
        [Route("Candidates/GetCandidateByElection")]
        public async Task<ActionResult<List<Candidate>>> GetCandidatesByElection(int electionID)
        {
            var response = await service.GetCandidatesByElectionAsync(electionID);
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return null;
        }
 
    }
}
