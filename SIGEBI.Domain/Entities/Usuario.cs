using SIGEBI.Domain.Base;

namespace SIGEBI.Domain.Entities
{
    public class Usuario : AuditEntity
    {
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public required string Contrasena { get; set; }
        public required string Estado { get; set; }

        public required int RolId { get; set; }
        public required Rol Rol { get; set; }

        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public ICollection<Penalizacion> Penalizaciones { get; set; } = new List<Penalizacion>();
        public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
        public ICollection<Reservacion> Reservaciones { get; set; } = new List<Reservacion>();
    }
}