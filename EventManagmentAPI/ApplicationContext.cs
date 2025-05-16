using EventsCore;
using EventsCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagmentAPI
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
            
        }
        DbSet<Event>Events { get; set; }

        internal async Task UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
