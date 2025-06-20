using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Reservacion : AuditEntity
    {
        public required int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public required int LibroId { get; set; }
        public required Libro Libro { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public DateTime Expira { get; set; } = DateTime.UtcNow.AddDays(7);

        // Nueva propiedad para estado de la reservación
        public string Estado { get; set; } = "Activa";
    }
}