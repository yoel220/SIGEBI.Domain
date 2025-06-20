using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Penalizacion : AuditEntity
    {
        public required int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public required int PrestamoId { get; set; }
        public required Prestamo Prestamo { get; set; }

        public decimal Monto { get; set; }
        public required string Motivo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public required string Estado { get; set; }
    }
}