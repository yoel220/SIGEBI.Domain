using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class RolRepository : GeneryRepository<Rol>, IRolRepository
    {
        public RolRepository(AppDbContext context) : base(context)
        {
        }
       

    }
}