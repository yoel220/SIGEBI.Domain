

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class LibroService : GeneryService<Libro>, ILibroService
    {
        public LibroService(IGeneryRepository<Libro> repository) : base(repository)
        {
        }
    }
}
