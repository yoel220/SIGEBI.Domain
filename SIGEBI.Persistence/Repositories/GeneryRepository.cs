

using Sigebi.Aplication.Interfaces.Repository;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class GeneryRepository<T> : IGeneryRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GeneryRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task Add(T Entity)
        {
            try
            {
                if (Entity == null)
                {
                    throw new ArgumentNullException(nameof(Entity), "Entity cannot be null");
                }
                _context.Set<T>().Add(Entity);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new InvalidOperationException("An error occurred while adding the entity.", ex);
            }
        }

        public Task Delete(Guid id)
        {
            try
            {

                var entity = _context.Set<T>().Find(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }
                _context.Set<T>().Remove(entity);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new InvalidOperationException("An error occurred while deleting the entity.", ex);
            }
        }

        public Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return Task.FromResult(_context.Set<T>().AsEnumerable());
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new InvalidOperationException("An error occurred while retrieving all entities.", ex);
            }
        }

        public Task<T> GetById(Guid id)
        {
            try
            {
                var entity = _context.Set<T>().Find(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }
                return Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new InvalidOperationException("An error occurred while retrieving the entity by ID.", ex);
            }
        }

        public Task Update(T Entity)
        {
            try
            {
                if (Entity == null)
                {
                    throw new ArgumentNullException(nameof(Entity), "Entity cannot be null");
                }
                _context.Set<T>().Update(Entity);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new InvalidOperationException("An error occurred while updating the entity.", ex);
            }
        }
    }
}
