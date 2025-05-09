using EventsCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagmentAPI.Repository
{
    public class BaseRepository <T>: IBaseRepository<T> where T : class
    {
        private readonly Context context;

        public BaseRepository(Context context)
        {
            this.context = context;
        }

        public async Task AddAsAsync(T entity)
        {
            await context.AddAsync(entity);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
