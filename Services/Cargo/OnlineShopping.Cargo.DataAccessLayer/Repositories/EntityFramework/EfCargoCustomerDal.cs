using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Persistance;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;

public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
{
    public EfCargoCustomerDal(CargoContext cargoContext) : base(cargoContext)
    {
    }
}
