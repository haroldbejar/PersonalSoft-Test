using Domain.Models;

namespace Services.Services
{
    public interface ILocalidadService : IBaseService<Localidad>
    {
        Task<Localidad> GetLocalidadByName(string name);
    }
}
