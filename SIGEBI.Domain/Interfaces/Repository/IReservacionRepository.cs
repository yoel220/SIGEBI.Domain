using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservacion>> GetAllAsync();
        Task<Reservacion?> GetByIdAsync(int id);
        Task<Reservacion> AddAsync(Reservacion reservacion);
        Task UpdateAsync(Reservacion reservacion);
        Task DeleteAsync(int id);
    }
}