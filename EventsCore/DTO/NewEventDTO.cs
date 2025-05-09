using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.DTO
{
    public class NewEventDTO
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Venue { get; set; }
        [Range(0 , int.MaxValue)]
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Image { get; set; }
    }
}
