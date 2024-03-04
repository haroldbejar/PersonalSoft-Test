using Domain.Models;
using Repositories;
using Repositories.Repositories;

namespace Services.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService, IValidationsService<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IBaseRepository<Cliente> repository, IClienteRepository clienteRepository)
            :base(repository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> GetClienteByName(string name)
        {
            return await _clienteRepository.GetClienteByName(name);
        }

        public override async Task InsertAsync(Cliente cliente)
        {
            var validated = ValidBeforeInsert(cliente);
            if (!validated) throw new ArgumentException("The entity couldn't be validated!");
            await base.InsertAsync(cliente);
        }

        public bool ValidBeforeInsert(Cliente cliente)
        {
            var identificacion = cliente.Identificacion;
            if ( identificacion == null || string.IsNullOrWhiteSpace(identificacion) )
            {
                return false;
            } 
            return true;
        }
    }
}
