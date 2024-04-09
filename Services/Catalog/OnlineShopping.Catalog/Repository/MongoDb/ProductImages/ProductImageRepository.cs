using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Repository.MongoDb.ProductImages;

public class ProductImageRepository : MongoRepository<ProductImage>,IProductImageRepository
{
    public ProductImageRepository(IDatabaseSettings databaseSettings) : base(databaseSettings, databaseSettings.ProductImageCollectionName)
    {
    }
}
