using EventsCore.Models;

namespace EventManagementMVC.Repository
{
    public class EventsAPI
    {
        public HttpClient client = new HttpClient();

        public EventsAPI()
        {
            client.BaseAddress = new Uri("http://localhost:5180/");
        }
        public async Task<List<Event>?> GetEventsAsync(int count = -1)
        {
            var res = await client.GetFromJsonAsync<List<Event>>($"/api/Events/getAll/{count}");
            return res;
        }
        
        public async Task<Event> GetEventAsync(int id)
        {
            var res = await client.GetFromJsonAsync<Event>($"api/Events?id={id}");
            return res;
        }
    }
}
