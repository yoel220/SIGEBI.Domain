using Sigebi.Aplication.Interfaces.Repository;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IPrestamoRepository : IGeneryRepository<Prestamo>
    {
        Task<IEnumerable<Prestamo>> GetActiveLoansAsync();
    }
}
