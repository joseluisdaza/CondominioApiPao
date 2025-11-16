using Condominio.API.Repository.Entities;
using System.Linq.Expressions;

namespace Condominio.API.Repository.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class, IEntityBase
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> lambda);
    }
}
