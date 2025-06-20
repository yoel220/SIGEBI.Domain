using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces;
using SIGEBI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace SIGEBI.Persistence.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly AppDbContext _context;

        public PrestamoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prestamo>> GetAllAsync()
        {
            return await _context.Prestamos.ToListAsync();
        }

        public async Task<Prestamo?> GetByIdAsync(int id)
        {
            return await _context.Prestamos.FindAsync(id);
        }

        public async Task<Prestamo> AddAsync(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task UpdateAsync(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ReturnBookAsync(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                prestamo.FechaDevolucion = DateTime.Now;
                _context.Prestamos.Update(prestamo);
                await _context.SaveChangesAsync();
            }
        }
    }
}