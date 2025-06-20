using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notificacion>> GetAllAsync();
        Task<Notificacion?> GetByIdAsync(int id);
        Task<Notificacion> AddAsync(Notificacion entity);
        Task UpdateAsync(Notificacion entity);
        Task DeleteAsync(int id);
    }
}