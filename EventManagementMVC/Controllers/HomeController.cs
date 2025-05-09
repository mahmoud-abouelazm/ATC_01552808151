using EventManagementMVC.Models;
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
        public HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client.BaseAddress = new Uri("http://localhost:5180/");
            
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public async Task<IActionResult> Events()
        {
            var res = await client.GetFromJsonAsync<Event>("api/Events?id=2");
            return Json(res);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
