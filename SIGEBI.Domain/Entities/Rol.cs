using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Rol : AuditEntity
    {
        public required string NombreRol { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}