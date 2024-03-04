using Domain.Data;
using Domain.Models;
using MongoDB.Driver;

namespace Repositories.Repositories
{
    public class ReservacionRepository : BaseRepository<Reservacion>, IReservacionRepository
    {
        private readonly IMongoCollection<Reservacion> _reservacionCollection;
        public ReservacionRepository(IMilesCarRentalDatabaseSettings settings)
            : base(settings, settings.ReservacionCollection)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var dataBase = mongoClient.GetDatabase(settings.DatabaseName);
            _reservacionCollection = dataBase.GetCollection<Reservacion>(settings.ReservacionCollection);
        }
    }
}
