

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;

namespace Sigebi.Aplication.Service
{
    public class PrestamoService : GeneryService<Prestamo>, IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;   
        public PrestamoService(IGeneryRepository<Prestamo> repository) : base(repository)
        {
            _prestamoRepository = (IPrestamoRepository)repository ?? throw new ArgumentNullException(nameof(repository), "El repositorio de préstamos no puede ser nulo.");
        }

        public async Task<IEnumerable<Prestamo>> GetActiveLoansAsync()
        {
            try
            {
                return await _prestamoRepository.GetActiveLoansAsync();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, logging, etc.
                throw new ApplicationException("Error al obtener los préstamos activos.", ex);

            }
        }

        public Task<Prestamo> GetLoanDetailsAsync(Guid loanId)
        {
            throw new NotImplementedException();
        }
    }
}
