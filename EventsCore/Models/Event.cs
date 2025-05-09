using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Venue { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string imageUrl { get; set; }
    }
}
