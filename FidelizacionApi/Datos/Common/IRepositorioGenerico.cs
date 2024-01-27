using System.Linq.Expressions;

namespace Datos.Common
{
    public interface IRepositorioGenerico<T>
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "",
            bool isTracking = false);

        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> ExecuteStoredProcedure(string stroredProcedure, IDictionary<string, object> parameters);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
