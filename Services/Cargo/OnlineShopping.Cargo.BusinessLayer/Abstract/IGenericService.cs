using System.Linq.Expressions;

namespace OnlineShopping.Cargo.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    Task TInsertAsync(T entity);
    Task TUpdateAsync(T entity);
    Task TDeleteAsync(int id);
    Task<T> TGetByIdAsync(Expression<Func<T, bool>>? predicate = null);
    Task<List<T>> TGetAllAsync(Expression<Func<T, bool>>? predicate = null);
}
