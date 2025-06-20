
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class AutorRepository : GeneryRepository<Autor>, IAutorRepository
    {
        public AutorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
