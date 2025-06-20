using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;

        public AutorRepository(AppDbContext context) => _context = context;

        public async Task<Autor?> GetByIdAsync(int id) =>
            await _context.Autores.FindAsync(id);

        public async Task<IEnumerable<Autor>> GetAllAsync() =>
            await _context.Autores.ToListAsync();

        public async Task AddAsync(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var autor = await GetByIdAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
