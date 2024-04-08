using System.Linq.Expressions;

namespace OnlineShopping.Catalog.Repository;

public interface IRepository<T>
{
    Task CreateAsync(T entity);
    Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    Task UpdateAsync(T entity, Expression<Func<T, bool>> filter);
    Task DeleteAsync(Expression<Func<T, bool>> filter);
}
