using Domain.Data;
using Domain.Models;
using MongoDB.Driver;

namespace Repositories.Repositories
{
    public class LocalidadRepository : BaseRepository<Localidad>, ILocalidadRepository
    {
        private readonly IMongoCollection<Localidad> _localidadCollection;
        public LocalidadRepository(IMilesCarRentalDatabaseSettings settings)
            : base(settings, settings.LocalidadCollection)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _localidadCollection = dataBase.GetCollection<Localidad>(settings.LocalidadCollection);
        }

        public async Task<Localidad> GetLocalidadByName(string name)
        {
            var filter = Builders<Localidad>.Filter.Eq("nombre", name);
            var result = await _localidadCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
    }
}
