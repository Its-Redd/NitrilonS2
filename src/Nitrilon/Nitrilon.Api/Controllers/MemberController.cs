using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        /// <summary>
        /// Get all members.
        /// </summary>
        /// <returns>A list of all members.</returns>
        [HttpGet]
        public IActionResult GetAllMembers()
        {
            MemberRepo repo = new();
            return Ok(repo.GetAllMembers());
        }

        /// <summary>
        /// Create a new member.
        /// </summary>
        /// <param name="newMember">The new member to create.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
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

        /// <summary>
        /// Update a member by ID.
        /// </summary>
        /// <param name="member">The member to update.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
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

        /// <summary>
        /// Delete a member.
        /// </summary>
        /// <param name="member">The member to delete.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpDelete]
        public IActionResult DeleteMember(Member member)
        {
            MemberRepo repo = new();
            try
            {
                repo.DeleteMember(member);
                return Ok();
            }
            catch
            {
                throw new Exception("Could not delete member");
            }
        }
    }
}
