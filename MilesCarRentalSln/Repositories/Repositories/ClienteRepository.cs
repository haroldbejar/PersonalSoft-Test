using Domain.Data;
using Domain.Models;
using MongoDB.Driver;

namespace Repositories.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clientCollection;
        public ClienteRepository(IMilesCarRentalDatabaseSettings settings)
            :base(settings, settings.ClienteCollection)
        {
                var mongoClient = new MongoClient(settings.ConnectionString);
                var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
                _clientCollection = dataBase.GetCollection<Cliente>(settings.ClienteCollection);
        }

        public async Task<Cliente> GetClienteByName(string name)
        {
            var filter = Builders<Cliente>.Filter.Eq("nombre", name);
            return await _clientCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
