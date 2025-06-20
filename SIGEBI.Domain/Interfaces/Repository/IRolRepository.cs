using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IRolRepository
    {
        Task<Rol?> GetByIdAsync(int id); // Permite null
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol> AddAsync(Rol rol);
        Task UpdateAsync(Rol rol);
        Task DeleteAsync(int id);
    }
}