using Domain.Data;
using Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace Repositories.Repositories
{
    public class VehiculoRepository : BaseRepository<Vehiculo>, IVehiculoRepository
    {
        private readonly IMongoCollection<Vehiculo> _vehiculoCollection;
        public VehiculoRepository(IMilesCarRentalDatabaseSettings settings)
            : base(settings, settings.VehiculoCollection)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _vehiculoCollection = dataBase.GetCollection<Vehiculo>(settings.VehiculoCollection);
        }

        public async Task<List<Vehiculo>> GetVehiculosByLocalidadId(string param)
        {
            var filtro = Builders<Vehiculo>.Filter.And(
                    Builders<Vehiculo>.Filter.Eq(v => v.LocalidadId, param),
                    Builders<Vehiculo>.Filter.Eq(v => v.Disponibilidad, true)
                );

            return await _vehiculoCollection.Find(filtro).ToListAsync();
        }

        public async Task<List<Vehiculo>> GetVehiculosByMarcaOrModelo(string param)
        {
            var filterBuilder = Builders<Vehiculo>.Filter;
            var filtro = filterBuilder.Or(
                    filterBuilder.Eq("marca", param),
                    filterBuilder.Regex("modelo", 
                        new BsonRegularExpression(new Regex(param, RegexOptions.IgnoreCase)))
                );
            var vehiculos = await _vehiculoCollection.Find(filtro).ToListAsync();
            return vehiculos;
        }
    }
}
