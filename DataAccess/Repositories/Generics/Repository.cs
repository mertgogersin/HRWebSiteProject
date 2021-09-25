using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Generics
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HRContext context;
        DbSet<T> _object;
        public Repository(HRContext context)
        {
            this.context = context;
            _object = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _object.AddAsync(entity);
        }

        public void Delete(T entity) //isActive: false olacağı için update methodunu çağırdım.
        {
            Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _object.ToListAsync();
        }

        public async Task<T> GetByIDAsync(Guid id)
        {
            return await _object.FindAsync(id);
        }

        public IEnumerable<T> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return _object.Where(predicate);
        }

        public void Update(T entity) //örneğin sadece şifre değiştirdin diyelim, bütün entity i service kısmında doldur ki diğer kolonları null getirmesin (service layerda id ile çekip passwordu update yap bu methoda yolla.
        {
            _object.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
