using Domain.Models;

namespace Services.Services
{
    public interface IVehiculoService : IBaseService<Vehiculo>
    {
        Task<List<Vehiculo>> GetVehiculosByMarcaOrModelo(string param);

        Task<List<Vehiculo>> GetVehiculosByLocalidadId(string param);
    }
}
