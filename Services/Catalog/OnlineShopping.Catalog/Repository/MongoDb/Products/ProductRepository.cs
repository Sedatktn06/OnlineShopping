using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Repository.MongoDb.Products;

public class ProductRepository : MongoRepository<Product>, IProductRepository
{
    public ProductRepository(IDatabaseSettings databaseSettings) : base(databaseSettings, databaseSettings.ProductCollectionName)
    {
    }
}
