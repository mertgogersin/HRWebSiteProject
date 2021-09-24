using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByID(Guid id);  
        Task AddAsync(T entity);
        void Update(T entity);
        void DeleteAsync(T entity);
    }
}
