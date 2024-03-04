using Domain.Models;

namespace Repositories.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> GetClienteByName(string name);
    }
}
