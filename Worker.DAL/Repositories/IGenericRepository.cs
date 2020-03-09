using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Worker.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int? skip, int? take);
        Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate);
        Task<IEnumerable<T>> GetAllOrderByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate, int? skip, int? take);
        Task<IEnumerable<T>> GetAllOrderByDescendingAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate);
        Task<IEnumerable<T>> GetAllOrderByDescendingAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sortPredicate, int? skip, int? take);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
