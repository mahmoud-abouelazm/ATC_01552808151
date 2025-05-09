using EventsCore;
using EventsCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagmentAPI
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {
            
        }
        DbSet<Event>Events { get; set; }
    }
}
