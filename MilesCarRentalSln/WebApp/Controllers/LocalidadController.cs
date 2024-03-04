using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : BaseController<Localidad>
    {
        private readonly ILocalidadService _localidadService;

        public LocalidadController(
            IBaseService<Localidad> service,
            ILocalidadService localidadService)
            :base(service)
        {
            _localidadService = localidadService;
        }

        [HttpGet("localidadbyname/{name}")]
        public async Task<ActionResult> GetLocalildadByName(string name)
        {
            try
            {
                if (name == null)
                {
                    return BadRequest("EL parámetro no puede ser nulo");
                }

                var result = await _localidadService.GetLocalidadByName(name);
                return Ok(result);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
