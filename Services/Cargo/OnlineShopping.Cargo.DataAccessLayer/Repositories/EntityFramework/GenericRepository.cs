using Microsoft.EntityFrameworkCore;
using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Persistance;
using System.Linq.Expressions;

namespace OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly CargoContext _cargoContext;

    public GenericRepository(CargoContext cargoContext)
    {
        _cargoContext = cargoContext;
    }

    public async Task DeleteAsync(int id)
    {
        var value = _cargoContext.Set<T>().Find(id);
        _cargoContext.Set<T>().Remove(value);
        await _cargoContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate != null ? await _cargoContext.Set<T>().Where(predicate).ToListAsync() : await _cargoContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
    {
        var value = await _cargoContext.Set<T>().SingleOrDefaultAsync(predicate);
        return value;
    }

    public async Task InsertAsync(T entity)
    {
        _cargoContext.Set<T>().Add(entity);
        await _cargoContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _cargoContext.Set<T>().Update(entity);
        await _cargoContext.SaveChangesAsync();
    }
}
