using Sigebi.Aplication.Interfaces.Repository;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IGeneryRepository<Usuario>
    {
       
        Task<Usuario> GetByEmailAsync(string email);
       
    }
}