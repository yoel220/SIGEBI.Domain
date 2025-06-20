
using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class PenalizacionService : GeneryService<Penalizacion>, IPenalizacionService
    {
        public PenalizacionService(IGeneryRepository<Penalizacion> repository) : base(repository)
        {
        }
    }
}
