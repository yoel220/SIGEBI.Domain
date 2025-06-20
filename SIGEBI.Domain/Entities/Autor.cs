using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Autor : AuditEntity
    {
        public required string Nombre { get; set; }
        public ICollection<LibroAutor> LibroAutores { get; set; } = new List<LibroAutor>();
    }
}