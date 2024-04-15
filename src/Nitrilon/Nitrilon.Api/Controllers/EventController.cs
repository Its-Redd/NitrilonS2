using Microsoft.AspNetCore.Mvc;
using Nitrilon.Api.Models;
using System.Diagnostics;

namespace Nitrilon.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private int _eventId = 0;
        private Event _event = new();
        private static List<Event> _events = new();

        [HttpPost(Name = "CreateEvent")]
        public IActionResult CreateEvent(Event newEvent)
        {
            try
            {
                Event alreadyExists  = _events.Find(e => e.EventId == newEvent.EventId);
                if (alreadyExists != null) return BadRequest("Event already exists");

                _events.Add(newEvent);
                Debug.WriteLine($"Event {newEvent.Name} created");
                _eventId++; // REMOVE THIS LINE AFTER REMOVING EventId FROM Event MODEL
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet(Name = "GetAllEvents")]
        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }




    }
}
