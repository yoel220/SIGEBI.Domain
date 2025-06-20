

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class NotificacionesService : GeneryService<Notificacion>, INotificacionesService
    {
        public NotificacionesService(IGeneryRepository<Notificacion> repository) : base(repository)
        {
        }
    }
}
