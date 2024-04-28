using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Persistance;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;

public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
{
    public EfCargoOperationDal(CargoContext cargoContext) : base(cargoContext)
    {
    }
}
