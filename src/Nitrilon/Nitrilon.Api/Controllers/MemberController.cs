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
            catch
            {
                throw new Exception("Could not create member");
            }
        }

        // Update member by id
        [HttpPut]
        public IActionResult UpdateMember(Member member)
        {
            MemberRepo repo = new();
            try
            {
                repo.UpdateMember(member);
                return Ok();
            }
            catch
            {
                throw new Exception("Could not update member");
            }
        }

        [HttpDelete]
        public IActionResult DeleteMember(int id)
        {
            MemberRepo repo = new();
            try
            {
                repo.DeleteMember(id);
                return Ok();
            }
            catch
            {
                throw new Exception("Could not delete member");
            }
        }



    }
}
