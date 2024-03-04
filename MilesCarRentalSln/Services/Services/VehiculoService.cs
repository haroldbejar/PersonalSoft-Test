using Domain.Models;
using Repositories;
using Repositories.Repositories;

namespace Services.Services
{
    public class VehiculoService : BaseService<Vehiculo>, IVehiculoService, IValidationsService<Vehiculo>
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        public VehiculoService(IBaseRepository<Vehiculo> repository, IVehiculoRepository vehiculoRepository)
            :base(repository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<List<Vehiculo>> GetVehiculosByLocalidadId(string param)
        {
            return await _vehiculoRepository.GetVehiculosByLocalidadId(param);
        }

        public async Task<List<Vehiculo>> GetVehiculosByMarcaOrModelo(string param)
        {
            return await _vehiculoRepository.GetVehiculosByMarcaOrModelo(param);
        }

        public override async Task InsertAsync(Vehiculo vehiculo)
        {
            var validated = ValidBeforeInsert(vehiculo);
            if (!validated) throw new ArgumentException("The entity couldn't be validated!");
            await base.InsertAsync(vehiculo);
        }
        public bool ValidBeforeInsert(Vehiculo vehiculo)
        {
            var result = true;
            var marca = vehiculo.Modelo;
            var modelo = vehiculo.Marca;
            var localidad = vehiculo.LocalidadId;
            if (marca == null) result = false;
            if (modelo == null) result = false;
            if (localidad == null) result = false;

            return result;
        }
    }
}
