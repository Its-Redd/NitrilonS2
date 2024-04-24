﻿using Microsoft.AspNetCore.Mvc;

using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingsController : Controller
    {
        [HttpPost]
        public IActionResult AddEventRating(int eventId, int ratingId)
        {
            try
            {
                Repository r = new();
                int createdId = r.SaveEventRating(eventId, ratingId);
                return Ok(createdId);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }



        [HttpGet]
        public ActionResult<EventRatingData> GetEventRatingDataFor(int eventId)
        {
            Repository repository = new();
            EventRatingData eventRatingData = repository.GetEventRatingDataBy(eventId);
            return Ok(eventRatingData);
        }
    }
}