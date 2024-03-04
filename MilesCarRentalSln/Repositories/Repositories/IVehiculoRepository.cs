using Domain.Models;

namespace Repositories.Repositories
{
    public interface IVehiculoRepository : IBaseRepository<Vehiculo>
    {
        Task<List<Vehiculo>> GetVehiculosByMarcaOrModelo(string param);

        Task<List<Vehiculo>> GetVehiculosByLocalidadId(string param);
    }
}
