using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nitrilon.Api.Controllers
{
    public class MemberController : ControllerBase
    {
        [HttpGet]
        [Route("api/member")]
        public IActionResult GetAllMembers()
        {
            return Ok();
        }

        [HttpPost]
        [Route("api/member")]
        public IActionResult CreateMember()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/member")]
        public IActionResult DeleteMember()
        {
            return Ok();
        }
        


    }
}
