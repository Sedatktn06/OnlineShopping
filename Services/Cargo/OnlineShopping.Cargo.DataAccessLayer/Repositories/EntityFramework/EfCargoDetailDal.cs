using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Persistance;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;

public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(CargoContext cargoContext) : base(cargoContext)
    {
    }
}
