using EventManagmentAPI.Repository;
using EventsCore.DTO;
using EventsCore.Interfaces;
using EventsCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Events : ControllerBase
    {
        private readonly IBaseRepository<Event> eventRepository;
        private readonly ImageHandler imageHandler;

        public Events(IBaseRepository<Event> eventRepository , ImageHandler imageHandler)
        {
            this.eventRepository = eventRepository;
            this.imageHandler = imageHandler;
        }
        [HttpGet]
        public async Task<IActionResult>getEvent(int id)
        {
            var result = await eventRepository.FindByIdAsync(id);
            return (result == null ? BadRequest("Event Not Fount") : Ok(result));
        }
        [HttpPost]
        public async Task<IActionResult> createEvent(NewEventDTO newEventDTO)
        {
            Event _event = new Event() { 
                Category = newEventDTO.Category,
                Date = newEventDTO.Date,
                Description = newEventDTO.Description,
                EventName = newEventDTO.EventName,
                Price = newEventDTO.Price
                ,Venue = newEventDTO.Venue,
                imageUrl = await imageHandler.SaveImageAsync(newEventDTO.Image , "uploads/events")
            };
            await eventRepository.AddAsAsync(_event);
            return Ok(_event);
        }

    }
}
