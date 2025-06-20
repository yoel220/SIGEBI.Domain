using Microsoft.AspNetCore.Mvc;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;

namespace SIGEBI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroAutorController : ControllerBase
    {
        private readonly ILibroAutorRepository _repository;
        public LibroAutorController(ILibroAutorRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{libroId:int}/{autorId:int}")]
        public async Task<IActionResult> Get(int libroId, int autorId)
        {
            var entity = await _repository.GetByIdAsync(libroId, autorId);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LibroAutor entity)
        {
            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { libroId = entity.LibroId, autorId = entity.AutorId }, entity);
        }

        [HttpPut("{libroId:int}/{autorId:int}")]
        public async Task<IActionResult> Update(int libroId, int autorId, [FromBody] LibroAutor entity)
        {
            if (libroId != entity.LibroId || autorId != entity.AutorId)
                return BadRequest();

            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{libroId:int}/{autorId:int}")]
        public async Task<IActionResult> Delete(int libroId, int autorId)
        {
            await _repository.DeleteAsync(libroId, autorId);
            return NoContent();
        }
    }
}