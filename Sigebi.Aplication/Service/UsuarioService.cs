using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class UsuarioService : GeneryService<Usuario>, IUsuarioService
    {
        public UsuarioService(IGeneryRepository<Usuario> repository) : base(repository)
        {
        }
    }
}
