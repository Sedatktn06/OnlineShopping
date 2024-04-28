using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Persistance;
using OnlineShopping.Cargo.EntityLayer.Concrete;

namespace OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;

public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
{
    public EfCargoCompanyDal(CargoContext cargoContext) : base(cargoContext)
    {
    }
}
