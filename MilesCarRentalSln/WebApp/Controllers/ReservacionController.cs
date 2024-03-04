using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionController : BaseController<Reservacion>
    {
        private readonly IReservacionService _reservacionService;
        private readonly IClienteService _clienteService;

        public ReservacionController(
            IBaseService<Reservacion> service,
            IReservacionService reservacionService,
            IClienteService clienteService)
            : base(service)
        {
            _reservacionService = reservacionService;
            _clienteService = clienteService;
        }
       
    }
}
