using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IBaseService<Cliente>, BaseService<Cliente>>();  
            services.AddScoped<IBaseService<Vehiculo>, BaseService<Vehiculo>>();
            services.AddScoped<IBaseService<Localidad>, BaseService<Localidad>>();
            services.AddScoped<IBaseService<Reservacion>, BaseService<Reservacion>>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddScoped<ILocalidadService, LocalidadService>();
            services.AddScoped<IReservacionService, ReservacionService>();
            services.AddScoped<IValidationsService<Cliente>, ClienteService>();
            services.AddScoped<IValidationsService<Vehiculo>, VehiculoService>();
            services.AddScoped<IValidationsService<Localidad>, LocalidadService>();
            services.AddScoped<IValidationsService<Reservacion>, ReservacionService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
