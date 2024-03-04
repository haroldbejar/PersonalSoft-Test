using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(string id)
        {
            var entity = await _service.GetByIdAsync(id);
            try
            {
                if (entity == null) return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create([FromBody] T entity)
        {
            try
            {
                if (entity == null) return BadRequest();
                await _service.InsertAsync(entity);
                return Ok(entity);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(string id, T entity)
        {
            var isExist = await _service.GetByIdAsync(id);
            if (isExist == null) return NotFound();

            try
            {
                await _service.UpdateAsync(id, entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if (entity == null) return NotFound();

                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
