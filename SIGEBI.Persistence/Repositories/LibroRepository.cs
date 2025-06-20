using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly AppDbContext _context;

        public LibroRepository(AppDbContext context) => _context = context;

        public async Task<Libro?> GetByIdAsync(int id) =>
            await _context.Libros.FindAsync(id);

        public async Task<IEnumerable<Libro>> GetAllAsync() =>
            await _context.Libros.ToListAsync();

        public async Task<Libro> AddAsync(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task UpdateAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var libro = await GetByIdAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Libro?> GetByISBNAsync(string isbn)
        {
            return await _context.Libros.FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task<IEnumerable<Libro>> GetByTituloAsync(string titulo)
        {
            return await _context.Libros
                .Where(l => EF.Functions.Like(l.Titulo, $"%{titulo}%"))
                .ToListAsync();
        }

        public async Task UpdateCantidadAsync(int libroId, int nuevaCantidad)
        {
            var libro = await _context.Libros.FindAsync(libroId);
            if (libro != null)
            {
                libro.Cantidad = nuevaCantidad; // ✅ Usamos 'Cantidad' como está en la entidad
                _context.Libros.Update(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAutorToLibroAsync(int libroId, int autorId)
        {
            var exists = await _context.LibroAutores
                .AnyAsync(la => la.LibroId == libroId && la.AutorId == autorId);

            if (!exists)
            {
                var libroAutor = new LibroAutor
                {
                    LibroId = libroId,
                    AutorId = autorId
                };

                await _context.LibroAutores.AddAsync(libroAutor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAutorFromLibroAsync(int libroId, int autorId)
        {
            var libroAutor = await _context.LibroAutores
                .FirstOrDefaultAsync(la => la.LibroId == libroId && la.AutorId == autorId);

            if (libroAutor != null)
            {
                _context.LibroAutores.Remove(libroAutor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
