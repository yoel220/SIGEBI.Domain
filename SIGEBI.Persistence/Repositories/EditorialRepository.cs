using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class EditorialRepository : GeneryRepository<Editorial>, IEditorialRepository
    {
        private readonly AppDbContext _context;
        public EditorialRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Libro>> GetLibrosByEditorialAsync(int editorialId)
        {
            try
            {
               
                var editorial = await _context.Editoriales.FindAsync(editorialId);
                if (editorial is null)
                {
                    throw new KeyNotFoundException($"No se encontró la editorial con ID {editorialId}");
                }
               
                var libros = await _context.Libros
                    .Where(libro => libro.EditorialId == editorialId)
                    .ToListAsync();
                return libros;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener los libros por editorial", ex);
            }
        }
    }
}