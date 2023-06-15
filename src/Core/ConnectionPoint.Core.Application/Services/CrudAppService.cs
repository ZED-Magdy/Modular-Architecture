using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Core.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Core.Application.Services;

public abstract class CrudAppService<TEntity, TKey, TDto> : ICrudAppService<TKey, TDto>
    where TEntity : FullAuditedEntity
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public CrudAppService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public virtual async Task<PaginatedResultDto<TDto>> GetListAsync(PaginationRequestDto input, CancellationToken cancellationToken = default)
    {
        var skipCount = (input.Page - 1)  * input.PerPage;
        List<TEntity> entities;
        if (!string.IsNullOrEmpty(input.Search))
        {
            entities = await _repository.GetListAsync(
                GetFilterExpression(input.Search), skipCount, input.PerPage,
                GetSortingFilter(input.SortBy),
                input.SortDirection == "desc", cancellationToken);
        }
        else
        {
            entities = await _repository.GetListAsync(skipCount, input.PerPage, GetSortingFilter(input.SortBy),input.SortDirection == "desc", cancellationToken);
        }
        
        var totalCount = await _repository.CountAsync(x => x.Id != Guid.Empty, cancellationToken);
        var dtos = _mapper.Map<List<TEntity>, List<TDto>>(entities);
        var totalPages = (int)Math.Ceiling((double)totalCount / input.PerPage);
        return new PaginatedResultDto<TDto>(input.Page, input.PerPage,totalCount, totalPages, dtos);
    }
    
    public virtual async Task<TDto?> CreateAsync(TDto input, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TDto, TEntity>(input);
        entity = await _repository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<TEntity, TDto>(entity);
    }
    
    public virtual async Task<TDto?> UpdateAsync(TKey id, TDto input, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(x => x.Id.Equals(id), cancellationToken);
        if (entity == null)
        {
            return default;
        }
        entity = _mapper.Map(input, entity);
        entity = await _repository.UpdateAsync(entity, cancellationToken);
        return _mapper.Map<TEntity, TDto>(entity);
    }
    
    public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(x => x.Id.Equals(id), cancellationToken);
    }
    
    public virtual async Task<TDto?> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity =  await _repository.GetAsync(x => x.Id.Equals(id), cancellationToken);
        if (entity == null)
        {
            return default;
        }
        return _mapper.Map<TEntity, TDto>(entity);
    }

    protected virtual Expression<Func<TEntity, bool>> GetFilterExpression(string search)
    {
        return (x) => EF.Functions.Like(x.Id.ToString(), $"%{search}%");
    }
    protected virtual Expression<Func<TEntity, object>> GetSortingFilter(string? inputSortBy)
    {
        return x => x.CreatedOn;
    }
}

public abstract class CrudAppService<TEntity, TKey, TDto, TCreateDto,
    TUpdateDto> : ICrudAppService<TKey, TDto, TCreateDto,
    TUpdateDto> where TEntity : FullAuditedEntity
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public CrudAppService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public virtual async Task<PaginatedResultDto<TDto>> GetListAsync(PaginationRequestDto input, CancellationToken cancellationToken = default)
    {
        var skipCount = (input.Page - 1)  * input.PerPage;
        List<TEntity> entities;
        if (!string.IsNullOrEmpty(input.Search))
        {
            entities = await _repository.GetListAsync(
                GetFilterExpression(input.Search), skipCount, input.PerPage,
                GetSortingFilter(input.SortBy),
                input.SortDirection == "desc", cancellationToken);
        }
        else
        {
            entities = await _repository.GetListAsync(skipCount, input.PerPage, GetSortingFilter(input.SortBy),input.SortDirection == "desc", cancellationToken);
        }
        
        var totalCount = await _repository.CountAsync(x => x.Id != Guid.Empty, cancellationToken);
        var dtos = _mapper.Map<List<TEntity>, List<TDto>>(entities);
        var totalPages = (int)Math.Ceiling((double)totalCount / input.PerPage);
        return new PaginatedResultDto<TDto>(input.Page, input.PerPage,totalCount, totalPages, dtos);
    }
    public virtual async Task<TDto?> CreateAsync(TCreateDto input, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<TCreateDto, TEntity>(input);
        entity = await _repository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<TEntity, TDto>(entity);
    }
    
    public virtual async Task<TDto?> UpdateAsync(TKey id, TUpdateDto input, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(x => x.Id.Equals(id), cancellationToken);
        if (entity == null)
        {
            return default;
        }
        entity = _mapper.Map(input, entity);
        entity = await _repository.UpdateAsync(entity, cancellationToken);
        return _mapper.Map<TEntity, TDto>(entity);
    }
    
    public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(x => x.Id.Equals(id), cancellationToken);
    }
    
    public virtual async Task<TDto?> GetAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity =  await _repository.GetAsync(x => x.Id.Equals(id), cancellationToken);
        if (entity == null)
        {
            return default;
        }
        return _mapper.Map<TEntity, TDto>(entity);
    }
    protected virtual Expression<Func<TEntity, bool>> GetFilterExpression(string search)
    {
        return (x) => EF.Functions.Like(x.Id.ToString(), $"%{search}%");
    }
    protected virtual Expression<Func<TEntity, object>> GetSortingFilter(string? inputSortBy)
    {
        return x => x.CreatedOn;
    }

}