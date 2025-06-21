


namespace SIGEBI.Domain.Entities
{
    public class Rol : AuditEntity
    {
        public Guid id;

        public required string NombreRol { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}