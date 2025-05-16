using EventManagementMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsAPI events;

        public EventsController(EventsAPI events)
        {
            this.events = events;
        }
        public IActionResult Book(int id)
        {
            return View();
        }
        public async Task<IActionResult> view(int id)
        {
            var res = await events.GetEventAsync(id);
            return View(res);
        }
    }
}
