using Domain.Models;

namespace Services.Services
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<Cliente> GetClienteByName(string name);
    }
}
