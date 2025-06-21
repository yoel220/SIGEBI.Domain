

namespace SIGEBI.Domain.Entities
{
    public class Autor 
    {
        public object id;

        public required string Nombre { get; set; }
        public required string Apellido { get; set; }


        public ICollection<LibroAutor> LibroAutores { get; set; } = new List<LibroAutor>();
    }
}