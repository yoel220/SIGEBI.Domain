using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class LibroRepository : GeneryRepository<Libro>, ILibroRepository
    {
        private readonly AppDbContext _context;
        public LibroRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAutorToLibroAsync(int libroId, int autorId, LibroAutor libroAutor)
        {
            try
            {
                var libro = await _context.Libros.Include(l => l.LibroAutores)
                                                                  .FirstOrDefaultAsync(l => l.id == libroId);
                if (libro is null)
                {
                    throw new Exception("Libro no encontrado");
                }
                var autor = await _context.Autores.FindAsync(autorId);
                if (autor is null)
                {
                    throw new Exception("Autor no encontrado");
                }
                if (!libro.LibroAutores.Any(a => a.AutorId == autorId))
                {
                    libro.LibroAutores.Add(libroAutor);
                    
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al añadir autor al libro: {ex.Message}");

            }
        }
        public async Task<Libro?> GetByISBNAsync(string isbn)
        {
            try
            {
                return await _context.Libros
                                    .Include(l => l.LibroAutores)
                                    .ThenInclude(la => la.Autor)
                                    .FirstOrDefaultAsync(l => l.ISBN == isbn);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al obtener libro por ISBN: {ex.Message}");

            }
        }

        public async Task<IEnumerable<Libro>> GetByTituloAsync(string titulo)
        {
            try
            {
                return await _context.Libros
                                                    .Include(l => l.LibroAutores)
                                                    .ThenInclude(la => la.Autor)
                                                    .Where(l => l.Titulo.Contains(titulo))
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al obtener libros por título: {ex.Message}");
            }
        }
        public async Task RemoveAutorFromLibroAsync(int libroId, int autorId)
        {
            try
            {
                var libro = await _context.Libros.Include(l => l.LibroAutores)
                                                                                  .FirstOrDefaultAsync(l => l.id == libroId);
                if (libro is null)
                {
                    throw new Exception("Libro no encontrado");
                }
                var autor = await _context.Autores.FindAsync(autorId);
                if (autor is null)
                {
                    throw new Exception("Autor no encontrado");
                }
                var libroAutor = libro.LibroAutores.FirstOrDefault(la => la.AutorId == autorId);
                if (libroAutor != null)
                {
                    libro.LibroAutores.Remove(libroAutor);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al eliminar autor del libro: {ex.Message}");

            }
        }

        public async Task UpdateCantidadAsync(int libroId, int nuevaCantidad)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(libroId);
                if (libro is null)
                {
                    throw new Exception("Libro no encontrado");
                }
                libro.Cantidad = nuevaCantidad;
                _context.Libros.Update(libro);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al actualizar cantidad del libro: {ex.Message}");
            }
        }
    }
}
