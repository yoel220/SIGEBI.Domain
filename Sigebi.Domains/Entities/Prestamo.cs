

namespace SIGEBI.Domain.Entities
{
    public class Prestamo : AuditEntity
    {
        public Guid id;

        public required int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public required int LibroId { get; set; }
        public required Libro Libro { get; set; }

        public DateTime FechaPrestamo { get; set; } = DateTime.UtcNow;

        // Fecha estimada o pactada para la devolución
        public DateTime? FechaDevolucion { get; set; }

        // Nueva propiedad: Fecha real de devolución
        public DateTime? FechaDevolucionReal { get; set; }

        public required string Estado { get; set; }

        public ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();
    }
}