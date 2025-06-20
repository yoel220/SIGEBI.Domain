
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class LibroAutorRepository : GeneryRepository<LibroAutor>, ILibroAutorRepository
    {
        public LibroAutorRepository(AppDbContext context) : base(context)
        {
        }
       
      
    }
}