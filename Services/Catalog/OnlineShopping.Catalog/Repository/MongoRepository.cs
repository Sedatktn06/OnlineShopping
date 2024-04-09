using MongoDB.Bson;
using MongoDB.Driver;
using OnlineShopping.Catalog.DbSettings;
using System.Linq.Expressions;

namespace OnlineShopping.Catalog.Repository;

public class MongoRepository<T> : IRepository<T> where T: new()
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository(IDatabaseSettings databaseSettings,string collectionName)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }
    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter)
    {
        //var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        if (filter == null)
        {
            filter = _ => true;
        }
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task UpdateAsync(T entity, Expression<Func<T, bool>> filter)
    {
        var options = new ReplaceOptions { IsUpsert = true };
        await _collection.ReplaceOneAsync(filter, entity, options);
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> filter)
    {
        await _collection.DeleteOneAsync(filter);
    }
}
