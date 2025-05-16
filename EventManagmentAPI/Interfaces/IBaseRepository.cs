using EventManagmentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task AddAsAsync(T entity);

        public Task UpdateAsAsync(T entity);


        public Task<T> FindByIdAsync(int id);

        public Task<List<T>> GetAll();

        public Task<List<T>> GetAllWithConditionAsync(Expression<Func<T, bool>> condition, int limit = -1);

    }
}
