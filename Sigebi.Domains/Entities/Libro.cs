

namespace SIGEBI.Domain.Entities
{
    public class Libro : AuditEntity
    {
        public int id;

        public required string ISBN { get; set; }
        public required string Titulo { get; set; }
        public int Cantidad { get; set; }

        public required int EditorialId { get; set; }
        public required Editorial Editorial { get; set; }

        public ICollection<LibroAutor> LibroAutores { get; set; } = new List<LibroAutor>();
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public ICollection<Reservacion> Reservaciones { get; set; } = new List<Reservacion>();
    }
}