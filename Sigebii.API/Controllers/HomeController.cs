using Microsoft.AspNetCore.Mvc;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebii.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {



            private readonly IAutorService _autorService;
            private readonly IEditorService _editorService;
            private readonly ILibroAutorService _libroAutorService;
            private readonly ILibroService _libroService;
            private readonly INotificacionesService _notificacionesService;
            private readonly IPenalizacionService _penalizacionService;
            private readonly IPrestamoService _prestamoService;
            private readonly IReservacionService _reservacionService;
            private readonly IRolService _rolService;
            private readonly IUsuarioService _usuarioService;

         public HomeController(
                IAutorService autorService,
                IEditorService editorService,
                ILibroAutorService libroAutorService,
                ILibroService libroService,
                INotificacionesService notificacionesService,
                IPenalizacionService penalizacionService,
                IPrestamoService prestamoService,
                IReservacionService reservacionService,
                IRolService rolService,
                IUsuarioService usuarioService)
        { 
                _autorService = autorService ?? throw new ArgumentNullException(nameof(autorService));
                _editorService = editorService ?? throw new ArgumentNullException(nameof(editorService));
                _libroAutorService = libroAutorService ?? throw new ArgumentNullException(nameof(libroAutorService));
                _libroService = libroService ?? throw new ArgumentNullException(nameof(libroService));
                _notificacionesService = notificacionesService ?? throw new ArgumentNullException(nameof(notificacionesService));
                _penalizacionService = penalizacionService ?? throw new ArgumentNullException(nameof(penalizacionService));
                _prestamoService = prestamoService ?? throw new ArgumentNullException(nameof(prestamoService));
                _reservacionService = reservacionService ?? throw new ArgumentNullException(nameof(reservacionService));
                _rolService = rolService ?? throw new ArgumentNullException(nameof(rolService));
                _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            }

        
            #region Autor Endpoints
            [HttpGet("autores")]
            public async Task<ActionResult<IEnumerable<Autor>>> GetAllAutores()
            {
                try
                {
                    var autores = await _autorService.GetAllAsync();
                    return Ok(autores);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("autores/{id}")]
            public async Task<ActionResult<Autor>> GetAutorById(Guid id)
            {
                try
                {
                    var autor = await _autorService.GetByIdAsync(id);
                    if (autor == null)
                        return NotFound($"Autor con ID {id} no encontrado");
                    return Ok(autor);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("autores")]
            public async Task<ActionResult<Autor>> CreateAutor([FromBody] Autor autor)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newAutor = await _autorService.CreateAsync(autor);
                    return CreatedAtAction(nameof(GetAutorById), new { id = newAutor.id }, newAutor);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("autores/{id}")]
            public async Task<ActionResult<Autor>> UpdateAutor(Guid id, [FromBody] Autor autor)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != (Guid)autor.id)
                        return BadRequest("El ID no coincide con el autor a actualizar");

                    var updatedAutor = await _autorService.UpdateAsync(autor);
                    return Ok(updatedAutor);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("autores/{id}")]
            public async Task<ActionResult> DeleteAutor(Guid id)
            {
                try
                {
                    var result = await _autorService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Autor con ID {id} no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Editorial Endpoints
            [HttpGet("editoriales")]
            public async Task<ActionResult<IEnumerable<Editorial>>> GetAllEditoriales()
            {
                try
                {
                    var editoriales = await _editorService.GetAllAsync();
                    return Ok(editoriales);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("editoriales/{id}")]
            public async Task<ActionResult<Editorial>> GetEditorialById(Guid id)
            {
                try
                {
                    var editorial = await _editorService.GetByIdAsync(id);
                    if (editorial == null)
                        return NotFound($"Editorial con ID {id} no encontrada");
                    return Ok(editorial);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("editoriales")]
            public async Task<ActionResult<Editorial>> CreateEditorial([FromBody] Editorial editorial)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newEditorial = await _editorService.CreateAsync(editorial);
                    return CreatedAtAction(nameof(GetEditorialById), new { id = newEditorial.id }, newEditorial);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("editoriales/{id}")]
            public async Task<ActionResult<Editorial>> UpdateEditorial(Guid id, [FromBody] Editorial editorial)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != Guid.Parse(editorial.id.ToString()))
                    return BadRequest("El ID no coincide con la editorial a actualizar");

                    var updatedEditorial = await _editorService.UpdateAsync(editorial);
                    return Ok(updatedEditorial);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("editoriales/{id}")]
            public async Task<ActionResult> DeleteEditorial(Guid id)
            {
                try
                {
                    var result = await _editorService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Editorial con ID {id} no encontrada");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Libro Endpoints
            [HttpGet("libros")]
            public async Task<ActionResult<IEnumerable<Libro>>> GetAllLibros()
            {
                try
                {
                    var libros = await _libroService.GetAllAsync();
                    return Ok(libros);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("libros/{id}")]
            public async Task<ActionResult<Libro>> GetLibroById(Guid id)
            {
                try
                {
                    var libro = await _libroService.GetByIdAsync(id);
                    if (libro == null)
                        return NotFound($"Libro con ID {id} no encontrado");
                    return Ok(libro);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("libros")]
            public async Task<ActionResult<Libro>> CreateLibro([FromBody] Libro libro)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newLibro = await _libroService.CreateAsync(libro);
                    return CreatedAtAction(nameof(GetLibroById), new { id = newLibro.id }, newLibro);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("libros/{id}")]
            public async Task<ActionResult<Libro>> UpdateLibro(Guid id, [FromBody] Libro libro)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != Guid.Parse(libro.id.ToString()))
                    return BadRequest("El ID no coincide con el libro a actualizar");

                    var updatedLibro = await _libroService.UpdateAsync(libro);
                    return Ok(updatedLibro);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("libros/{id}")]
            public async Task<ActionResult> DeleteLibro(Guid id)
            {
                try
                {
                    var result = await _libroService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Libro con ID {id} no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region LibroAutor Endpoints
            [HttpGet("libro-autores")]
            public async Task<ActionResult<IEnumerable<LibroAutor>>> GetAllLibroAutores()
            {
                try
                {
                    var libroAutores = await _libroAutorService.GetAllAsync();
                    return Ok(libroAutores);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("libro-autores/{id}")]
            public async Task<ActionResult<LibroAutor>> GetLibroAutorById(Guid id)
            {
                try
                {
                    var libroAutor = await _libroAutorService.GetByIdAsync(id);
                    if (libroAutor == null)
                        return NotFound($"LibroAutor con ID {id} no encontrado");
                    return Ok(libroAutor);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("libro-autores")]
            public async Task<ActionResult<LibroAutor>> CreateLibroAutor([FromBody] LibroAutor libroAutor)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newLibroAutor = await _libroAutorService.CreateAsync(libroAutor);
                    return CreatedAtAction(nameof(GetLibroAutorById), new { id = newLibroAutor.id }, newLibroAutor);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("libro-autores/{id}")]
            public async Task<ActionResult<LibroAutor>> UpdateLibroAutor(Guid id, [FromBody] LibroAutor libroAutor)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                if (id !=Guid.Parse(libroAutor.id.ToString()))
                        return BadRequest("El ID no coincide con el LibroAutor a actualizar");

                    var updatedLibroAutor = await _libroAutorService.UpdateAsync(libroAutor);
                    return Ok(updatedLibroAutor);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("libro-autores/{id}")]
            public async Task<ActionResult> DeleteLibroAutor(Guid id)
            {
                try
                {
                    var result = await _libroAutorService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"LibroAutor con ID {id} no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Notificaciones Endpoints
            [HttpGet("notificaciones")]
            public async Task<ActionResult<IEnumerable<Notificacion>>> GetAllNotificaciones()
            {
                try
                {
                    var notificaciones = await _notificacionesService.GetAllAsync();
                    return Ok(notificaciones);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("notificaciones/{id}")]
            public async Task<ActionResult<Notificacion>> GetNotificacionById(Guid id)
            {
                try
                {
                    var notificacion = await _notificacionesService.GetByIdAsync(id);
                    if (notificacion == null)
                        return NotFound($"Notificación con ID {id} no encontrada");
                    return Ok(notificacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("notificaciones")]
            public async Task<ActionResult<Notificacion>> CreateNotificacion([FromBody] Notificacion notificacion)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newNotificacion = await _notificacionesService.CreateAsync(notificacion);
                    return CreatedAtAction(nameof(GetNotificacionById), new { id = newNotificacion.id }, newNotificacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("notificaciones/{id}")]
            public async Task<ActionResult<Notificacion>> UpdateNotificacion(Guid id, [FromBody] Notificacion notificacion)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != notificacion.id)
                        return BadRequest("El ID no coincide con la notificación a actualizar");

                    var updatedNotificacion = await _notificacionesService.UpdateAsync(notificacion);
                    return Ok(updatedNotificacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("notificaciones/{id}")]
            public async Task<ActionResult> DeleteNotificacion(Guid id)
            {
                try
                {
                    var result = await _notificacionesService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Notificación con ID {id} no encontrada");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Penalizaciones Endpoints
            [HttpGet("penalizaciones")]
            public async Task<ActionResult<IEnumerable<Penalizacion>>> GetAllPenalizaciones()
            {
                try
                {
                    var penalizaciones = await _penalizacionService.GetAllAsync();
                    return Ok(penalizaciones);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("penalizaciones/{id}")]
            public async Task<ActionResult<Penalizacion>> GetPenalizacionById(Guid id)
            {
                try
                {
                    var penalizacion = await _penalizacionService.GetByIdAsync(id);
                    if (penalizacion == null)
                        return NotFound($"Penalización con ID {id} no encontrada");
                    return Ok(penalizacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("penalizaciones")]
            public async Task<ActionResult<Penalizacion>> CreatePenalizacion([FromBody] Penalizacion penalizacion)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newPenalizacion = await _penalizacionService.CreateAsync(penalizacion);
                    return CreatedAtAction(nameof(GetPenalizacionById), new { id = newPenalizacion.id }, newPenalizacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("penalizaciones/{id}")]
            public async Task<ActionResult<Penalizacion>> UpdatePenalizacion(Guid id, [FromBody] Penalizacion penalizacion)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != penalizacion.id)
                        return BadRequest("El ID no coincide con la penalización a actualizar");

                    var updatedPenalizacion = await _penalizacionService.UpdateAsync(penalizacion);
                    return Ok(updatedPenalizacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("penalizaciones/{id}")]
            public async Task<ActionResult> DeletePenalizacion(Guid id)
            {
                try
                {
                    var result = await _penalizacionService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Penalización con ID {id} no encontrada");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Prestamos Endpoints
            [HttpGet("prestamos")]
            public async Task<ActionResult<IEnumerable<Prestamo>>> GetAllPrestamos()
            {
                try
                {
                    var prestamos = await _prestamoService.GetAllAsync();
                    return Ok(prestamos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("prestamos/activos")]
            public async Task<ActionResult<IEnumerable<Prestamo>>> GetActivePrestamos()
            {
                try
                {
                    var prestamos = await _prestamoService.GetActiveLoansAsync();
                    return Ok(prestamos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("prestamos/{id}")]
            public async Task<ActionResult<Prestamo>> GetPrestamoById(Guid id)
            {
                try
                {
                    var prestamo = await _prestamoService.GetByIdAsync(id);
                    if (prestamo == null)
                        return NotFound($"Préstamo con ID {id} no encontrado");
                    return Ok(prestamo);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("prestamos")]
            public async Task<ActionResult<Prestamo>> CreatePrestamo([FromBody] Prestamo prestamo)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newPrestamo = await _prestamoService.CreateAsync(prestamo);
                    return CreatedAtAction(nameof(GetPrestamoById), new { id = newPrestamo.id }, newPrestamo);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("prestamos/{id}")]
            public async Task<ActionResult<Prestamo>> UpdatePrestamo(Guid id, [FromBody] Prestamo prestamo)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != prestamo.id)
                        return BadRequest("El ID no coincide con el préstamo a actualizar");

                    var updatedPrestamo = await _prestamoService.UpdateAsync(prestamo);
                    return Ok(updatedPrestamo);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("prestamos/{id}")]
            public async Task<ActionResult> DeletePrestamo(Guid id)
            {
                try
                {
                    var result = await _prestamoService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Préstamo con ID {id} no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Reservaciones Endpoints
            [HttpGet("reservaciones")]
            public async Task<ActionResult<IEnumerable<Reservacion>>> GetAllReservaciones()
            {
                try
                {
                    var reservaciones = await _reservacionService.GetAllAsync();
                    return Ok(reservaciones);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("reservaciones/{id}")]
            public async Task<ActionResult<Reservacion>> GetReservacionById(Guid id)
            {
                try
                {
                    var reservacion = await _reservacionService.GetByIdAsync(id);
                    if (reservacion == null)
                        return NotFound($"Reservación con ID {id} no encontrada");
                    return Ok(reservacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("reservaciones")]
            public async Task<ActionResult<Reservacion>> CreateReservacion([FromBody] Reservacion reservacion)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newReservacion = await _reservacionService.CreateAsync(reservacion);
                    return CreatedAtAction(nameof(GetReservacionById), new { id = newReservacion.id }, newReservacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("reservaciones/{id}")]
            public async Task<ActionResult<Reservacion>> UpdateReservacion(Guid id, [FromBody] Reservacion reservacion)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != reservacion.id)
                        return BadRequest("El ID no coincide con la reservación a actualizar");

                    var updatedReservacion = await _reservacionService.UpdateAsync(reservacion);
                    return Ok(updatedReservacion);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("reservaciones/{id}")]
            public async Task<ActionResult> DeleteReservacion(Guid id)
            {
                try
                {
                    var result = await _reservacionService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Reservación con ID {id} no encontrada");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Roles Endpoints
            [HttpGet("roles")]
            public async Task<ActionResult<IEnumerable<Rol>>> GetAllRoles()
            {
                try
                {
                    var roles = await _rolService.GetAllAsync();
                    return Ok(roles);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("roles/{id}")]
            public async Task<ActionResult<Rol>> GetRolById(Guid id)
            {
                try
                {
                    var rol = await _rolService.GetByIdAsync(id);
                    if (rol == null)
                        return NotFound($"Rol con ID {id} no encontrado");
                    return Ok(rol);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("roles")]
            public async Task<ActionResult<Rol>> CreateRol([FromBody] Rol rol)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newRol = await _rolService.CreateAsync(rol);
                    return CreatedAtAction(nameof(GetRolById), new { id = newRol.id }, newRol);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("roles/{id}")]
            public async Task<ActionResult<Rol>> UpdateRol(Guid id, [FromBody] Rol rol)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != rol.id)
                        return BadRequest("El ID no coincide con el rol a actualizar");

                    var updatedRol = await _rolService.UpdateAsync(rol);
                    return Ok(updatedRol);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("roles/{id}")]
            public async Task<ActionResult> DeleteRol(Guid id)
            {
                try
                {
                    var result = await _rolService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Rol con ID {id} no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            #endregion

            #region Usuarios Endpoints
            [HttpGet("usuarios")]
            public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
            {
                try
                {
                    var usuarios = await _usuarioService.GetAllAsync();
                    return Ok(usuarios);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpGet("usuarios/{id}")]
            public async Task<ActionResult<Usuario>> GetUsuarioById(Guid id)
            {
                try
                {
                    var usuario = await _usuarioService.GetByIdAsync(id);
                    if (usuario == null)
                        return NotFound($"Usuario con ID {id} no encontrado");
                    return Ok(usuario);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPost("usuarios")]
            public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var newUsuario = await _usuarioService.CreateAsync(usuario);
                    return CreatedAtAction(nameof(GetUsuarioById), new { id = newUsuario.id }, newUsuario);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpPut("usuarios/{id}")]
            public async Task<ActionResult<Usuario>> UpdateUsuario(Guid id, [FromBody] Usuario usuario)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    if (id != Guid.Parse(usuario.id.ToString()))
                        return BadRequest("El ID no coincide con el usuario a actualizar");

                    var updatedUsuario = await _usuarioService.UpdateAsync(usuario);
                    return Ok(updatedUsuario);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            [HttpDelete("usuarios/{id}")]
            public async Task<ActionResult> DeleteUsuario(Guid id)
            {
                try
                {
                    var result = await _usuarioService.DeleteAsync(id);
                    if (result)
                        return NoContent();
                    return NotFound($"Usuario con ID {id} no encontrado");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

        }
    // End of HomeController.cs\
    #endregion
}