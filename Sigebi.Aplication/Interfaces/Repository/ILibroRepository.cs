
using Sigebi.Aplication.Interfaces.Repository;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface ILibroRepository : IGeneryRepository<Libro>
    {
      
        Task<Libro?> GetByISBNAsync(string isbn);
        Task<IEnumerable<Libro>> GetByTituloAsync(string titulo);
        Task UpdateCantidadAsync(int libroId, int nuevaCantidad);
        Task AddAutorToLibroAsync(int libroId, int autorId, LibroAutor libroAutor);
        Task RemoveAutorFromLibroAsync(int libroId, int autorId);
    }
}