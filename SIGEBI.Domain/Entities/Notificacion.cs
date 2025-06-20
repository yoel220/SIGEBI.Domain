using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Notificacion : AuditEntity
    {
        public required int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;
        public required string Mensaje { get; set; }
        public bool Leida { get; set; } = false;
    }
}