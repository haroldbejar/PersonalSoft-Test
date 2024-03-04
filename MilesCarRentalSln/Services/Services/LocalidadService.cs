using Domain.Models;
using Repositories;
using Repositories.Repositories;

namespace Services.Services
{
    public class LocalidadService : BaseService<Localidad>, ILocalidadService, IValidationsService<Localidad>
    {
        private readonly ILocalidadRepository _localidadRepository;
        public LocalidadService(IBaseRepository<Localidad> repository, ILocalidadRepository localidadRepository)
            :base(repository)
        {
            _localidadRepository = localidadRepository;
        }

        public async Task<Localidad> GetLocalidadByName(string name)
        {
            return await _localidadRepository.GetLocalidadByName(name);
        }

        public override async Task InsertAsync(Localidad localidad)
        {
            var validated = ValidBeforeInsert(localidad);
            if (!validated) throw new ArgumentException("The entity couldn't be validated!");
            await base.InsertAsync(localidad);
        }
        public bool ValidBeforeInsert(Localidad localidad)
        {
            var nombreLocaliad = localidad.Nombre;
            if ( nombreLocaliad == null || string.IsNullOrWhiteSpace(nombreLocaliad) ) 
            {
                return false;
            }

            return true;
        }
    }
}
