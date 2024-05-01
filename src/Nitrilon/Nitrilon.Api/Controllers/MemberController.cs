using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllMembers()
        {
            MemberRepo repo = new();
            return Ok(repo.GetAllMembers());
        }

        [HttpPost]
        public IActionResult CreateMember(Member newMember)
        {
            MemberRepo repo = new();
            try
            {
                repo.CreateMember(newMember);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception("Could not create member", e);
            }




        }

        [HttpDelete]
        public IActionResult DeleteMember()
        {
            return Ok();
        }



    }
}
