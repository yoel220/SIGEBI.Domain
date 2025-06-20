

using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;
using SIGEBI.Domain.Entities;

namespace Sigebi.Aplication.Service
{
    public class EditorService : GeneryService<Editorial>, IEditorService
    {
        public EditorService(IGeneryRepository<Editorial> repository) : base(repository)
        {
        }
    }
}
