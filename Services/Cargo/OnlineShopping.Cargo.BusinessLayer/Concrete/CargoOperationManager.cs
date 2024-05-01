using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;
using OnlineShopping.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace OnlineShopping.Cargo.BusinessLayer.Concrete;

public class CargoOperationManager : ICargoOperationService
{
    private readonly ICargoOperationDal _cargoOperationDal;

    public CargoOperationManager(ICargoOperationDal cargoOperationDal)
    {
        _cargoOperationDal = cargoOperationDal;
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoOperationDal.DeleteAsync(id);

    }

    public async Task<List<CargoOperation>> TGetAllAsync(Expression<Func<CargoOperation, bool>>? predicate = null)
    {
        var cargoDetails = await _cargoOperationDal.GetAllAsync(predicate);
        return cargoDetails;
    }

    public async Task<CargoOperation> TGetByIdAsync(Expression<Func<CargoOperation, bool>> predicate)
    {
        var cargoDetail = await _cargoOperationDal.GetByIdAsync(predicate);
        return cargoDetail;
    }

    public async Task TInsertAsync(CargoOperation entity)
    {
        await _cargoOperationDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoOperation entity)
    {
        await _cargoOperationDal.UpdateAsync(entity);
    }
}
