using EventManagementMVC.Models;
using EventManagementMVC.ModelView;
using EventManagementMVC.Repository;
using EventsCore;
using EventsCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EventManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventsAPI events;

        public HomeController(ILogger<HomeController> logger , EventsAPI events)
        {
            _logger = logger;
            this.events = events;
        }

        public async Task<IActionResult> Index()
        {
            HomeModelView model = new();
            model.LastEvents = await events.GetEventsAsync(3);
            model.AllEvents = await events.GetEventsAsync();
            return View(model);
        }
        public async Task<IActionResult> Events()
        {
            return Ok();
        }
        
    }
}
