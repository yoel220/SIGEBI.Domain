

namespace Sigebi.Aplication.Interfaces.Repository
{
    public interface IGeneryRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(Guid id);
    }
}
