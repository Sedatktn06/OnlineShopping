using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;
using OnlineShopping.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace OnlineShopping.Cargo.BusinessLayer.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompanyDal;

    public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
    {
        _cargoCompanyDal = cargoCompanyDal;
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoCompanyDal.DeleteAsync(id);
    }

    public async Task<List<CargoCompany>> TGetAllAsync(Expression<Func<CargoCompany, bool>>? predicate = null)
    {
        var cargoDetails = await _cargoCompanyDal.GetAllAsync(predicate);
        return cargoDetails;
    }

    public async Task<CargoCompany> TGetByIdAsync(Expression<Func<CargoCompany, bool>> predicate)
    {
        var cargoDetail = await _cargoCompanyDal.GetByIdAsync(predicate);
        return cargoDetail;
    }

    public async Task TInsertAsync(CargoCompany entity)
    {
        await _cargoCompanyDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoCompany entity)
    {
        await _cargoCompanyDal.UpdateAsync(entity);
    }
}
