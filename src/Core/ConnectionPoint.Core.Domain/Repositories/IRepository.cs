using System.Linq.Expressions;

namespace ConnectionPoint.Core.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take,
        CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take,
        Expression<Func<TEntity, object>> orderBy, bool isDescending = false,
        CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>> orderBy, bool isDescending = false,
        CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, object>> orderBy, bool isDescending = false,
        CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(int skip, int take, Expression<Func<TEntity, object>> orderBy,
        bool isDescending = false, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(int skip, int take, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<TEntity?> SingleOrDefaultAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<TEntity?> FirstAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> SingleAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> GetByIdAsync(Guid id, Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties);
}