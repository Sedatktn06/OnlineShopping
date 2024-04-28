using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace OnlineShopping.Cargo.BusinessLayer.Concrete;

public class CargoDetailManager : ICargoDetailService
{
    private ICargoDetailDal _cargoDetailDal;

    public CargoDetailManager(ICargoDetailDal cargoDetailDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoDetailDal.DeleteAsync(id);
    }

    public async Task<List<CargoDetail>> TGetAllAsync(Expression<Func<CargoDetail, bool>> predicate)
    {
        var cargoDetails = await _cargoDetailDal.GetAllAsync(predicate);
        return cargoDetails;
    }

    public async Task<CargoDetail> TGetByIdAsync(Expression<Func<CargoDetail, bool>> predicate)
    {
        var cargoDetail = await _cargoDetailDal.GetByIdAsync(predicate);
        return cargoDetail;
    }

    public async Task TInsertAsync(CargoDetail entity)
    {
        await _cargoDetailDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoDetail entity)
    {
        await _cargoDetailDal.UpdateAsync(entity);
    }
}
