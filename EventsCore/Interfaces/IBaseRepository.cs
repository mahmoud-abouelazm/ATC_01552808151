using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task AddAsAsync(T entity);
    }
}
