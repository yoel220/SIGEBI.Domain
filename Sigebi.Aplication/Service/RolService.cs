

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class RolService : GeneryService<Rol>, IRolService
    {
        public RolService(IGeneryRepository<Rol> repository) : base(repository)
        {
        }
    }
}
