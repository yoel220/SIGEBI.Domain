using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class PenalizationRepository : GeneryRepository<Penalizacion>, IPenalizationRepository
    {
        public PenalizationRepository(AppDbContext context) : base(context)
        {
        }
       

        
    }
}