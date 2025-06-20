using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces
{
    public interface IEditorialRepository
    {
        Task<IEnumerable<Editorial>> GetAllAsync();
        Task<Editorial?> GetByIdAsync(int id); // Cambiado a Editorial?
        Task<Editorial> AddAsync(Editorial editorial);
        Task UpdateAsync(Editorial editorial);
        Task DeleteAsync(int id);
        Task<IEnumerable<Libro>> GetLibrosByEditorialAsync(int editorialId); // Añadido si es necesario
    }
}