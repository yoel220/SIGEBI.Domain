using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces; // ✅ Interfaz correcta desde Domain
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reservacion?> GetByIdAsync(int id)
        {
            return await _context.Reservaciones.FindAsync(id);
        }

        public async Task<IEnumerable<Reservacion>> GetAllAsync()
        {
            return await _context.Reservaciones.ToListAsync();
        }

        public async Task<IEnumerable<Reservacion>> GetByUserIdAsync(int usuarioId)
        {
            return await _context.Reservaciones
                .Where(r => r.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<Reservacion> AddAsync(Reservacion reservation)
        {
            await _context.Reservaciones.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task UpdateAsync(Reservacion reservation)
        {
            _context.Reservaciones.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await GetByIdAsync(id);
            if (reservation != null)
            {
                _context.Reservaciones.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CancelAsync(int id)
        {
            var reservation = await GetByIdAsync(id);
            if (reservation is not null)
            {
                reservation.Estado = "Cancelada";
                _context.Reservaciones.Update(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}