using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetAllAsync();
        Task<Libro?> GetByIdAsync(int id);
        Task<Libro?> GetByISBNAsync(string isbn);
        Task<IEnumerable<Libro>> GetByTituloAsync(string titulo);
        Task<Libro> AddAsync(Libro libro);
        Task UpdateAsync(Libro libro);
        Task DeleteAsync(int id);
        Task UpdateCantidadAsync(int libroId, int nuevaCantidad);
        Task AddAutorToLibroAsync(int libroId, int autorId);
        Task RemoveAutorFromLibroAsync(int libroId, int autorId);
    }
}