using Domain.Models;

namespace Repositories.Repositories
{
    public interface ILocalidadRepository : IBaseRepository<Localidad>
    {

        Task<Localidad> GetLocalidadByName(string name);
    }
}
