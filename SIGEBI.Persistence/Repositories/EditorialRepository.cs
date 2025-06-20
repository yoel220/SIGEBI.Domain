using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly AppDbContext _context;

        public EditorialRepository(AppDbContext context) => _context = context;

        public async Task<Editorial?> GetByIdAsync(int id) =>
            await _context.Editoriales.FindAsync(id);

        public async Task<IEnumerable<Editorial>> GetAllAsync() =>
            await _context.Editoriales.ToListAsync();

        public async Task<Editorial> AddAsync(Editorial editorial)
        {
            await _context.Editoriales.AddAsync(editorial);
            await _context.SaveChangesAsync();
            return editorial; // 👈 Retorna la entidad agregada
        }

        public async Task UpdateAsync(Editorial editorial)
        {
            _context.Editoriales.Update(editorial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var editorial = await GetByIdAsync(id);
            if (editorial != null)
            {
                _context.Editoriales.Remove(editorial);
                await _context.SaveChangesAsync();
            }
        }

        // 👇 Implementación del nuevo método de la interfaz
        public async Task<IEnumerable<Libro>> GetLibrosByEditorialAsync(int editorialId)
        {
            return await _context.Libros
                .Where(l => l.EditorialId == editorialId)
                .ToListAsync();
        }
    }
}