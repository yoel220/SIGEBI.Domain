using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IPenalizationRepository
    {
        Task<IEnumerable<Penalizacion>> GetAllAsync();
        Task<Penalizacion?> GetByIdAsync(int id);
        Task<Penalizacion> AddAsync(Penalizacion entity);
        Task UpdateAsync(Penalizacion entity);
        Task DeleteAsync(int id);
    }
}