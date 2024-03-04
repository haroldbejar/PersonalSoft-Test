using Domain.Data;
using MongoDB.Driver;

namespace Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public BaseRepository(IMilesCarRentalDatabaseSettings settings, string collectionName)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _collection = dataBase.GetCollection<T>(collectionName);
        }

        #region CRUD
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _collection.Find(d => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }

        #endregion
    }
}
