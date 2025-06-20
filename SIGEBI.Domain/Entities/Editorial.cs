using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Editorial : AuditEntity
    {
        public required string Nombre { get; set; }
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}