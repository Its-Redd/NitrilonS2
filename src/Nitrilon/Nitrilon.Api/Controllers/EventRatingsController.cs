using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventRatingsController : Controller
    {
        [HttpPost(Name = "CreateEvent")]
        public IActionResult CreateEvent(int eventId, int ratingId)
        {
            try
            {
                Repository r = new();
                int createdId = r.SaveEventRating(eventId, ratingId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
