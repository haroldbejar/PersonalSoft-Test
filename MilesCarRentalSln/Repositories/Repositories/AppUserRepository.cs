using Domain.Data;
using Domain.Models;
using MongoDB.Driver;

namespace Repositories.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        private readonly IMongoCollection<AppUser> _collection;
        public AppUserRepository(IMilesCarRentalDatabaseSettings settings) 
            : base(settings, settings.UsuarioCollection)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _collection = dataBase.GetCollection<AppUser>(settings.UsuarioCollection);
        }

        public async Task<AppUser> GetUserByUserName(string userName)
        {
            var filter = Builders<AppUser>.Filter.Eq("username", userName);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
