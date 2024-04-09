using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Repository.MongoDb.ProductDetails;

public class ProductDetailRepository : MongoRepository<ProductDetail>,IProductDetailRepository
{
    public ProductDetailRepository(IDatabaseSettings databaseSettings) : base(databaseSettings, databaseSettings.ProductDetailCollectionName)
    {
    }
}
