using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Core.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConnectionPoint.Core.Infrastructure.Persistence;

public abstract class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : FullAuditedEntityDto
{
    private readonly ModuleDbContext _dbContext;

    public EFCoreRepository(ModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.Where(predicate).Skip(skip).Take(take).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take,
        Expression<Func<TEntity, object>> orderBy, bool isDescending = false,
        CancellationToken cancellationToken = default)
    {
        return isDescending
            ? await _dbContext.Set<TEntity>()!.Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                .ToListAsync(cancellationToken)
            : await _dbContext.Set<TEntity>()!.Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                .ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>> orderBy, bool isDescending = false,
        CancellationToken cancellationToken = default)
    {
        return isDescending
            ? await _dbContext.Set<TEntity>()!.Where(predicate).OrderByDescending(orderBy).ToListAsync(cancellationToken)
            : await _dbContext.Set<TEntity>()!.Where(predicate).OrderBy(orderBy).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, object>> orderBy, bool isDescending = false,
        CancellationToken cancellationToken = default)
    {
        return isDescending
            ? await _dbContext.Set<TEntity>()!.OrderByDescending(orderBy).ToListAsync(cancellationToken)
            : await _dbContext.Set<TEntity>()!.OrderBy(orderBy).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(int skip, int take, Expression<Func<TEntity, object>> orderBy,
        bool isDescending = false, CancellationToken cancellationToken = default)
    {
        return isDescending
            ? await _dbContext.Set<TEntity>()!.OrderByDescending(orderBy).Skip(skip).Take(take)
                .ToListAsync(cancellationToken)
            : await _dbContext.Set<TEntity>()!.OrderBy(orderBy).Skip(skip).Take(take).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(int skip, int take, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.Skip(skip).Take(take).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.ToListAsync(cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<TEntity>()!.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>()!.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<TEntity>()!.FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<TEntity>()!.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext.Set<TEntity>()!.Where(predicate).ToListAsync(cancellationToken);
        _dbContext.Set<TEntity>()!.RemoveRange(entities);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.AnyAsync(predicate, cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.CountAsync(predicate, cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.CountAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.LastOrDefaultAsync(predicate, cancellationToken);
    }
    public async Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.FirstAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> FirstAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.FirstAsync(cancellationToken);
    }

    public async Task<TEntity?> SingleAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _dbContext.Set<TEntity>()!.AsQueryable();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.SingleAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>()!.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _dbContext.Set<TEntity>()!.AsQueryable();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _dbContext.Set<TEntity>()!.AsQueryable();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.SingleOrDefaultAsync(predicate);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _dbContext.Set<TEntity>()!.AsQueryable();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.SingleOrDefaultAsync(predicate);
    }
}