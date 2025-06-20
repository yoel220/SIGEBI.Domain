

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class LibroAutorService : GeneryService<LibroAutor>, ILibroAutorService
    {
        public LibroAutorService(IGeneryRepository<LibroAutor> repository) : base(repository)
        {
        }
    }
}
