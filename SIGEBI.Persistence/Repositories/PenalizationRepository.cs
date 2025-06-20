using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces; // ✅ Usar la interfaz del dominio
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class PenalizationRepository : IPenalizationRepository
    {
        private readonly AppDbContext _context;

        public PenalizationRepository(AppDbContext context) => _context = context;

        public async Task<Penalizacion?> GetByIdAsync(int id) =>
            await _context.Penalizaciones.FindAsync(id);

        public async Task<IEnumerable<Penalizacion>> GetAllAsync() =>
            await _context.Penalizaciones.ToListAsync();

        public async Task<IEnumerable<Penalizacion>> GetByUserIdAsync(int usuarioId) =>
            await _context.Penalizaciones
                .Where(p => p.UsuarioId == usuarioId)
                .ToListAsync();

        public async Task<Penalizacion> AddAsync(Penalizacion penalizacion)
        {
            await _context.Penalizaciones.AddAsync(penalizacion);
            await _context.SaveChangesAsync();
            return penalizacion;
        }

        public async Task UpdateAsync(Penalizacion penalizacion)
        {
            _context.Penalizaciones.Update(penalizacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var penalizacion = await GetByIdAsync(id);
            if (penalizacion != null)
            {
                _context.Penalizaciones.Remove(penalizacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}