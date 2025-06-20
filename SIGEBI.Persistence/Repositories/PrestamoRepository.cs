using SIGEBI.Domain.Entities;
using SIGEBI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Interfaces.Repository;

namespace SIGEBI.Persistence.Repositories
{
    public class PrestamoRepository : GeneryRepository<Prestamo>, IPrestamoRepository
    {
        private readonly AppDbContext _context;
        public PrestamoRepository(AppDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto no puede ser nulo");
        }

        public async Task<IEnumerable<Prestamo>> GetActiveLoansAsync()
        {
            try
            {
                return await _context.Prestamos
                                    .Include(p => p.Libro)
                                    .Include(p => p.Usuario)
                                    .Where(p => p.FechaDevolucion == null || p.FechaDevolucion > DateTime.Now)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new Exception("Error al obtener los préstamos activos", ex);

            }

        }
    }
}