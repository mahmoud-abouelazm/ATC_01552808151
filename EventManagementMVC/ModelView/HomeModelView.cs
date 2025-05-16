using EventsCore.Models;

namespace EventManagementMVC.ModelView
{
    public class HomeModelView
    {
        public List<Event> LastEvents { get; set; }
        public List<Event> AllEvents { get; set; }
    }
}
