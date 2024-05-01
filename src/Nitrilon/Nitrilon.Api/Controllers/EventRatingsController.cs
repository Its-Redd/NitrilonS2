using Microsoft.AspNetCore.Mvc;

using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    /// <summary>
    /// Controller for managing event ratings.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingsController : Controller
    {
        /// <summary>
        /// Adds a new event rating.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        /// <param name="ratingId">The ID of the rating.</param>
        /// <returns>The ID of the created event rating.</returns>
        [HttpPost]
        public IActionResult AddEventRating(int eventId, int ratingId)
        {
            try
            {
                EventRepo r = new();
                int createdId = r.SaveEventRating(eventId, ratingId);
                return Ok(createdId);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retrieves the event rating data for a specific event.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        /// <returns>The event rating data.</returns>
        [HttpGet]
        public ActionResult<EventRatingData> GetEventRatingDataFor(int eventId)
        {
            EventRepo repository = new();
            EventRatingData eventRatingData = repository.GetEventRatingDataBy(eventId);
            return Ok(eventRatingData);
        }
    }
}