using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;
using OnlineShopping.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace OnlineShopping.Cargo.BusinessLayer.Concrete;

public class CargoCustomerManager : ICargoCustomerService
{
    private readonly ICargoCustomerDal _cargoCustomerDal;

    public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
    {
        _cargoCustomerDal = cargoCustomerDal;
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoCustomerDal.DeleteAsync(id);
    }

    public async Task<List<CargoCustomer>> TGetAllAsync(Expression<Func<CargoCustomer, bool>> predicate)
    {
        var cargoDetails = await _cargoCustomerDal.GetAllAsync(predicate);
        return cargoDetails;
    }

    public async Task<CargoCustomer> TGetByIdAsync(Expression<Func<CargoCustomer, bool>> predicate)
    {
        var cargoDetail = await _cargoCustomerDal.GetByIdAsync(predicate);
        return cargoDetail;
    }

    public async Task TInsertAsync(CargoCustomer entity)
    {
        await _cargoCustomerDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoCustomer entity)
    {
        await _cargoCustomerDal.UpdateAsync(entity);
    }
}
