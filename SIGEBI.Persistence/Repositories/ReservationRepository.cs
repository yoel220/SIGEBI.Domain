using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class ReservationRepository : GeneryRepository<Reservacion>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}