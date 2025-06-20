using Microsoft.AspNetCore.Mvc;
using Sigebi.Aplication.Interfaces.Service;
using Sigebi.Aplication.Service;
using SIGEBI.Domain.Entities;

namespace Sigebii.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UserController(IUsuarioService _usuarioService)
        {
            usuarioService = _usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
        {
            try
            {
                var usuarios = await usuarioService.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(Guid id)
        {
            try
            {
                var usuario = await usuarioService.GetByIdAsync(id);

                if (usuario is null)
                {
                    return NotFound(new { message = $"Usuario con ID {id} no encontrado" });
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario is null)
                {
                    return BadRequest(new { message = "Los datos del usuario son requeridos" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuarioCreado = await usuarioService.CreateAsync(usuario);
                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuarioCreado.id }, usuarioCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Usuario>> UpdateUsuario(Guid id, [FromBody] Usuario usuario)
        //{
        //    try
        //    {
        //        if (usuario is null)
        //        {
        //            return BadRequest(new { message = "Los datos del usuario son requeridos" });
        //        }

        //        if (id !=usuario.id)
        //        {
        //            return BadRequest(new { message = "El ID del parámetro no coincide con el ID del usuario" });
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        // Verificar si el usuario existe
        //        var usuarioExistente = await usuarioService.GetByIdAsync(id);
        //        if (usuarioExistente is null)
        //        {
        //            return NotFound(new { message = $"Usuario con ID {id} no encontrado" });
        //        }

        //        var usuarioActualizado = await usuarioService.UpdateAsync(usuario);
        //        return Ok(usuarioActualizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
        //    }
        //}

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(Guid id)
        {
            try
            {
                // Verificar si el usuario existe
                var usuario = await usuarioService.GetByIdAsync(id);
                if (usuario is null)
                {
                    return NotFound(new { message = $"Usuario con ID {id} no encontrado" });
                }

                var resultado = await usuarioService.DeleteAsync(id);

                if (resultado)
                {
                    return Ok(new { message = "Usuario eliminado correctamente" });
                }

                return StatusCode(500, new { message = "Error al eliminar el usuario" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }
    }
}
