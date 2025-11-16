using Condominio.API.Repository.Context;
using Condominio.API.Repository.Entities;
using Condominio.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Condominio.API.Repository.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase
    {
        private readonly SqlContext _context;

        protected SqlContext Context { get { return _context; } }

        protected BaseRepository(SqlContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> lambda)
        {
            lambda.Compile();
            return await _context.Set<T>().Where(lambda).ToListAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            var entry = _context.Entry(entity);
            _context.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
