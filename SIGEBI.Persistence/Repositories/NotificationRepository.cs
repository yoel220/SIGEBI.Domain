using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces; // ✅ Interfaz corregida al dominio
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context) => _context = context;

        public async Task<Notificacion?> GetByIdAsync(int id) =>
            await _context.Notificaciones.FindAsync(id);

        public async Task<IEnumerable<Notificacion>> GetAllAsync() =>
            await _context.Notificaciones.ToListAsync();

        public async Task<IEnumerable<Notificacion>> GetByUserIdAsync(int usuarioId) =>
            await _context.Notificaciones
                .Where(n => n.UsuarioId == usuarioId)
                .ToListAsync();

        public async Task<Notificacion> AddAsync(Notificacion notification)
        {
            await _context.Notificaciones.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task UpdateAsync(Notificacion notification)
        {
            _context.Notificaciones.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var noti = await GetByIdAsync(id);
            if (noti != null)
            {
                _context.Notificaciones.Remove(noti);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkAsReadAsync(int id)
        {
            var notification = await GetByIdAsync(id);
            if (notification != null)
            {
                notification.Leida = true;
                _context.Notificaciones.Update(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}