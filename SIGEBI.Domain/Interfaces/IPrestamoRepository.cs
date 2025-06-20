using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<Prestamo>> GetAllAsync();
        Task<Prestamo?> GetByIdAsync(int id); // ← corregido aquí
        Task<Prestamo> AddAsync(Prestamo prestamo);
        Task UpdateAsync(Prestamo prestamo);
        Task DeleteAsync(int id);
        Task ReturnBookAsync(int id);
    }
}
