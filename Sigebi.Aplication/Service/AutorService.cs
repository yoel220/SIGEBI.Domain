

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class AutorService : GeneryService<Autor>, IAutorService
    {
        public AutorService(IGeneryRepository<Autor> repository) : base(repository)
        {
        }
    }
}
