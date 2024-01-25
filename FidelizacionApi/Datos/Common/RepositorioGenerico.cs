using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;

namespace Datos.Common
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly FidelizacionContext _context;

        public RepositorioGenerico(FidelizacionContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity != null)
            {
                var item = _context.Set<T>();
                item.Add(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", bool isTracking = false)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync()
                : await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedure(string stroredProcedure, IDictionary<string, object> parameters)
        {
            var query = new StringBuilder();
            query.Append($"EXEC {stroredProcedure} ");
            foreach (var parameter in parameters)
            {
                query.Append($"@{parameter.Key} = {parameter.Value.ToString()}{(parameters.LastOrDefault().Key.Equals(parameter.Key) ? "" : ",")}");
            }

            return await _context.Set<T>().FromSqlRaw(query.ToString()).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                var item = _context.Set<T>();
                item.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
