using Microsoft.EntityFrameworkCore;

namespace SIGEBI.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int recordsPerPage)
        {
            return query.Skip((page - 1) * recordsPerPage).Take(recordsPerPage);
        }
    }
}