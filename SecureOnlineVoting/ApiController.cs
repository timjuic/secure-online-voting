
using Microsoft.AspNetCore.Mvc;

namespace SecureOnlineVoting
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("smt")]
        public ActionResult<string> ReturnsSomething()
        {
            return "String kul";
        }
    }
}
