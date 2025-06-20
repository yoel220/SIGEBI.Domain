
using Sigebi.Aplication.Interfaces.Repository;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IEditorialRepository : IGeneryRepository<Editorial>
    {
       
        Task<IEnumerable<Libro>> GetLibrosByEditorialAsync(int editorialId); // Añadido si es necesario
    }
}