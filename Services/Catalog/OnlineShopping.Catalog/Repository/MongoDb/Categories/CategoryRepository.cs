using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Entities;

namespace OnlineShopping.Catalog.Repository.MongoDb.Categories;

public class CategoryRepository : MongoRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IDatabaseSettings databaseSettings) : base(databaseSettings, databaseSettings.CategoryCollectionName)
    {
    }
}
