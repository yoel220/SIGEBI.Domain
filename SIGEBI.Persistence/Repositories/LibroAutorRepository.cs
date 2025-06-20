using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class LibroAutorRepository : ILibroAutorRepository
    {
        private readonly AppDbContext _context;

        public LibroAutorRepository(AppDbContext context) => _context = context;

        public async Task<LibroAutor?> GetByIdAsync(int libroId, int autorId) =>
            await _context.LibroAutores
                .FirstOrDefaultAsync(la => la.LibroId == libroId && la.AutorId == autorId);

        public async Task<IEnumerable<LibroAutor>> GetAllAsync() =>
            await _context.LibroAutores.ToListAsync();

        public async Task<LibroAutor> AddAsync(LibroAutor libroAutor)
        {
            await _context.LibroAutores.AddAsync(libroAutor);
            await _context.SaveChangesAsync();
            return libroAutor;
        }

        public async Task UpdateAsync(LibroAutor libroAutor)
        {
            _context.LibroAutores.Update(libroAutor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int libroId, int autorId)
        {
            var entity = await GetByIdAsync(libroId, autorId);
            if (entity != null)
            {
                _context.LibroAutores.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}