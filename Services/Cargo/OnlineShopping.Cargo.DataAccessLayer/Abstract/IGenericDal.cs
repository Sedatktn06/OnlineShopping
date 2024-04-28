using System.Linq.Expressions;

namespace OnlineShopping.Cargo.DataAccessLayer.Abstract;

public interface IGenericDal<T> where T : class
{
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<T> GetByIdAsync(Expression<Func<T, bool>>? predicate = null);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
}
