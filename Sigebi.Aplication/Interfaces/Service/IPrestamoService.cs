

using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Interfaces.Service
{
    public interface IPrestamoService : IGeneryService<Prestamo>
    {
       
        Task<IEnumerable<Prestamo>> GetActiveLoansAsync();
        Task<Prestamo> GetLoanDetailsAsync(Guid loanId);
    }
    
}
