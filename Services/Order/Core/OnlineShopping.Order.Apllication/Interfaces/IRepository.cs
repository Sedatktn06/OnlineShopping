using System.Linq.Expressions;

namespace OnlineShopping.Order.Apllication.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GeatAllAsync();
    Task<T> GeatByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
}
