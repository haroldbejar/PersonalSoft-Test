using Domain.Models;
using Repositories;
using Repositories.Repositories;

namespace Services.Services
{
    public class ReservacionService : BaseService<Reservacion>, IReservacionService, IValidationsService<Reservacion>
    {
        private readonly IReservacionRepository _reservacionRepository;
        public ReservacionService(IBaseRepository<Reservacion> repository, IReservacionRepository reservacionRepository)
            :base(repository)
        {
            _reservacionRepository = reservacionRepository;
        }
        public override async Task InsertAsync(Reservacion reservacion)
        {
            var validated = ValidBeforeInsert(reservacion);
            if (!validated) throw new ArgumentException("The entity couldn't be validated!");
            await base.InsertAsync(reservacion);
        }
        public bool ValidBeforeInsert(Reservacion reservacion)
        {
            if (reservacion.ClienteId == null)
                return false;

            if (reservacion.VehiculoId == null)
                return false;

            if (reservacion.LocalidadRecogidaId == null)
                return false;

            if (reservacion.LocalidaDevolucionId == null)
                return false;

            if (reservacion.FechaRecogida <= DateTime.Now)
                return false;

            if (reservacion.FechaDevolucion <= reservacion.FechaRecogida)
                return false;

            return true;
        }
    }
}
