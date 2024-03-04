using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController<Cliente>
    {
        private readonly IClienteService _clienteService;
        public ClienteController(
            IBaseService<Cliente> service, 
            IClienteService clienteService)
            :base(service)
        {
            _clienteService = clienteService;
        }
    }
}
