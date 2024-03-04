using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBaseRepository<Cliente>, ClienteRepository>();
            services.AddScoped<IBaseRepository<Vehiculo>, VehiculoRepository>();
            services.AddScoped<IBaseRepository<Localidad>, LocalidadRepository>();
            services.AddScoped<IBaseRepository<Reservacion>, ReservacionRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<ILocalidadRepository, LocalidadRepository>();
            services.AddScoped<IReservacionRepository, ReservacionRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            return services;
        }
    }
}
