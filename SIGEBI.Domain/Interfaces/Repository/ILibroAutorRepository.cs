using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface ILibroAutorRepository
    {
        Task<IEnumerable<LibroAutor>> GetAllAsync();
        Task<LibroAutor?> GetByIdAsync(int idLibro, int idAutor);
        Task<LibroAutor> AddAsync(LibroAutor entity);
        Task UpdateAsync(LibroAutor entity);
        Task DeleteAsync(int idLibro, int idAutor);
    }
}