namespace SIGEBI.Domain.Entities
{
    public class LibroAutor
    {
        public object id;

        public int LibroId { get; set; }
        public Libro? Libro { get; set; }

        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}