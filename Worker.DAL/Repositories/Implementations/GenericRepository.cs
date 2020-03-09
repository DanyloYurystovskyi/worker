using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Worker.DAL.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private WorkerContext _context;

        public GenericRepository(WorkerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int? take, int? skip)
        {
            var query = _context.Set<T>().Where(predicate);
            return await GetPartOfQueryableAsync(query, skip, take);
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate, int? skip, int? take)
        {
            var query = _context.Set<T>().Where(predicate);
            query = query.OrderBy(sortPredicate);
            return await GetPartOfQueryableAsync(query, skip, take);
        }

        public async Task<IEnumerable<T>> GetAllOrderByDescendingAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate, int? skip, int? take)
        {
            var query = _context.Set<T>().Where(predicate);
            query = query.OrderByDescending(sortPredicate);
            return await GetPartOfQueryableAsync(query, skip, take);
        }

        private async Task<IEnumerable<T>> GetPartOfQueryableAsync(IQueryable<T> query, int? skip, int? take)
        {
            query = skip.HasValue ? query.Skip(skip.Value) : query;
            query = take.HasValue ? query.Take(take.Value) : query;
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetAllAsync(predicate, null, null);
        }

        public async Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate)
        {
            return await GetAllOrderByAsync(predicate, sortPredicate, null, null);
        }

        public async Task<IEnumerable<T>> GetAllOrderByDescendingAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate)
        {
            return await GetAllOrderByDescendingAsync(predicate, sortPredicate, null, null);
        }
    }
}
