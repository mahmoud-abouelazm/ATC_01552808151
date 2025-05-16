using EventsCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EventManagmentAPI.Repository
{
    public class BaseRepository <T>: IBaseRepository<T> where T : class
    {
        private readonly ApplicationContext context;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task AddAsAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsAsync(T entity)
        {
            await context.UpdateAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllWithConditionAsync(Expression<Func<T,bool>> condition, int limit = -1)
        {

            if(limit < 0)
                return await context.Set<T>().Where(condition).ToListAsync(); 
           
            return await context.Set<T>().Where(condition).Take(limit).ToListAsync(); 
        }

    }
}

