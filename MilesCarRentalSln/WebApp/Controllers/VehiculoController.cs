using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : BaseController<Vehiculo>
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(
            IBaseService<Vehiculo> service,
            IVehiculoService vehiculoService)
            :base(service)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet("vehiculosbyparam/{param}")]
        public async Task<ActionResult<List<Vehiculo>>> GetVehiculosByMarcaOrLocalidad(string param)
        {
            try
            {
                var result = await _vehiculoService.GetVehiculosByMarcaOrModelo(param);
                return Ok(result);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("vehiculosbylocalidad/{param}")]
        public async Task<ActionResult<List<Vehiculo>>> GetVehiculosByLocalidad(string param)
        {
            try
            {
                if (param == null)
                {
                    return BadRequest("EL parámetro no puede ser nulo");
                }
                var result = await _vehiculoService.GetVehiculosByLocalidadId(param);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
