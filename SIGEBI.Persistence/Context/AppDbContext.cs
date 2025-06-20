using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;


namespace SIGEBI.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<LibroAutor> LibroAutores { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Penalizacion> Penalizaciones { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



    }
}