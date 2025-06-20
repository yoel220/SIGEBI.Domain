

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class ReservacionesService : GeneryService<Reservacion>, IReservacionService
    {
        public ReservacionesService(IGeneryRepository<Reservacion> repository) : base(repository)
        {
        }
    }
}
