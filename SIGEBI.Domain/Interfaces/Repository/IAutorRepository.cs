using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IAutorRepository
    {
        Task<Autor?> GetByIdAsync(int id);
        Task<IEnumerable<Autor>> GetAllAsync();
        Task AddAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task DeleteAsync(int id);
    }
}