using Microsoft.AspNetCore.Mvc;

using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// Deletes an event by ID.
        /// </summary>
        /// <param name="id">The ID of the event to delete.</param>
        /// <returns>The result of the delete operation.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Updates an existing event.
        /// </summary>
        /// <param name="eventToUpdate">The event to update.</param>
        /// <returns>The result of the update operation.</returns>
        [HttpPut]
        public IActionResult Put(Event eventToUpdate)
        {
            return Ok();
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>A list of all events.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            EventRepo repository = new();
            List<Event> events = repository.GetAllEvents();
            return events;
        }

        /// <summary>
        /// Adds a new event.
        /// </summary>
        /// <param name="newEvent">The event to add.</param>
        /// <returns>The ID of the newly created event.</returns>
        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            try
            {
                EventRepo r = new();
                int createdId = r.Save(newEvent);
                return Ok(createdId);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}