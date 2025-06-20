
using Sigebi.Aplication.Interfaces.Repository;
using Sigebi.Aplication.Interfaces.Service;

namespace Sigebi.Aplication.Service
{
    public class GeneryService<T> : IGeneryService<T> where T : class
    {
        private readonly IGeneryRepository<T> _repository;

        public GeneryService(IGeneryRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción, registrar el error, etc.
                throw new Exception("Error al obtener todos los registros", ex);

            }
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción, registrar el error, etc.
                throw new Exception($"Error al obtener el registro con ID {id}", ex);

            }
        }
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _repository.Add(entity);
                return entity; // Retorna el objeto creado
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción, registrar el error, etc.
                throw new Exception("Error al crear el registro", ex);
            }
        }
        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                await _repository.Update(entity);
                return entity; // Retorna el objeto actualizado
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción, registrar el error, etc.
                throw new Exception("Error al actualizar el registro", ex);
            }

        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return true; // Retorna true si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción, registrar el error, etc.
                throw new Exception($"Error al eliminar el registro con ID {id}", ex);
            }
        }
    }
    
    
}
